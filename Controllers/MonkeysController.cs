using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MonkeyShelter.Entities;
using MonkeyShelter.Models;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using AutoMapper;
using MonkeyShelter.Services;
using System.Web.Http.OData;
using System.Web.Configuration;

namespace MonkeyShelter.Controllers
{
    public class MonkeysController : ApiController
    {
        
        private readonly IMapper _mapper;
        private readonly IMonkeyShelterRepository _monkeyShelterRepository;
        private readonly IFluctuationStateRepository _fluctuationStateRepository;

        public MonkeysController(IMapper mapper, IMonkeyShelterRepository monkeyShelterRepository, IFluctuationStateRepository fluctuationStateRepository)
        {
            _mapper = mapper;
            _monkeyShelterRepository = monkeyShelterRepository;
            _fluctuationStateRepository = fluctuationStateRepository;
        }

        //GET ALL ASYNC : api/Monkeys/
        [ResponseType(typeof(Monkey))]
        public async Task<IHttpActionResult> GetMonkeysAsync()
        {

            var monkeyEntities = await _monkeyShelterRepository.GetMonkeysAsync();
            return Ok(_mapper.Map<IEnumerable<MonkeyDto>>(monkeyEntities));

        }

        //GET MONKEY BY ID ASYNC: api/Monkeys/string
        [ResponseType(typeof(Monkey))]
        public async Task<IHttpActionResult> GetMonkeyAsync(string id)
        {

            var monkeyEntity = await _monkeyShelterRepository.GetMonkeyAsync(id);
            if (monkeyEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MonkeyDto>(monkeyEntity));

        }

        //DELETE: api/Monkeys/string
        public async Task<IHttpActionResult> DeleteMonkey(string id)
        {
            var item = await _monkeyShelterRepository.GetMonkeyAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var countLeaves = _fluctuationStateRepository.CountLeavesForToday();
            var countArrivals = _fluctuationStateRepository.CountArrivalForToday();
            if (countLeaves > 5)
            {
                return BadRequest("Not Allowed over 5 Leaves per day.");
            }

            else if ((countLeaves - countArrivals) > 2)
            {
                return BadRequest("Can't remove more monkeys untill you add monkeys.");
            }

            _monkeyShelterRepository.DeleteMonkey(item);
            await _monkeyShelterRepository.SaveChangesAsync();

            //code for 2nd Table
            var newFluct = new MonkeyFluctuationState();
            newFluct.FluctuationState = Common.FluctuationState.Left;
            _fluctuationStateRepository.AddFluctuation(newFluct);
            await _fluctuationStateRepository.SaveChangesAsync();

            return Ok();
        }

        //POST: api/Monkeys
        public async Task<IHttpActionResult> AddMonkey(MonkeyCreateDto monkeyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var count = _fluctuationStateRepository.CountArrivalForToday();
            if (count > 7)
            {
                return BadRequest();
            }

            var newMonkey = _mapper.Map<Monkey>(monkeyDto);
            _monkeyShelterRepository.AddMonkey(newMonkey);
            await _monkeyShelterRepository.SaveChangesAsync();

            //code for 2nd Table
            var newFluct = new MonkeyFluctuationState();
            newFluct.FluctuationState = Common.FluctuationState.Arrived;
            _fluctuationStateRepository.AddFluctuation(newFluct);
            await _fluctuationStateRepository.SaveChangesAsync();
            
            var createdMonkeyDto = _mapper.Map<MonkeyDto>(newMonkey);
            return CreatedAtRoute("DefaultApi", new { id = createdMonkeyDto.Id }, createdMonkeyDto);
        }

        //PUT: api/Monkeys/string
        [HttpPut]
        public async Task<IHttpActionResult> UpdateMonkeyWeight(string id, int weight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != monkeyUpdateDto.Id)
            //{
            //    return BadRequest("Mismatched IDs");
            //}

            var existingMonkey = await _monkeyShelterRepository.GetMonkeyAsync(id);
            if (existingMonkey == null)
            {
                return NotFound();
            }

            existingMonkey.Weight = weight;

            _monkeyShelterRepository.UpdateMonkey(existingMonkey);
            await _monkeyShelterRepository.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/species")]
        public IHttpActionResult GetSpecies()
        {
            return Ok(_monkeyShelterRepository.GetSpeciesWithCount());
        }

        [HttpGet]
        [Route("api/count")]
        public IHttpActionResult CountForToday()
        {
            return Ok(_fluctuationStateRepository.CountForToday());
        }


        [HttpGet]
        [Route("api/countArrival")]
        public IHttpActionResult CountArrivalForToday()
        {
            return Ok(_fluctuationStateRepository.CountArrivalForToday());
        }

        [HttpGet]
        [Route("api/speciesdate")]
        public IHttpActionResult GetSpeciesByDateRange(DateTime startDate, DateTime endDate)
        {
            return Ok(_monkeyShelterRepository.GetSpeciesByDateRange(startDate, endDate));
        }



        //[HttpPatch]
        //public async Task<IHttpActionResult> PatchMonkey(string id, Delta<MonkeyDto> monkeyDelta)
        //{
        //    if (monkeyDelta == null)
        //    {
        //        return BadRequest("Invalid patch data");
        //    }

        //    var existingMonkey = await _monkeyShelterRepository.GetMonkeyAsync(id);
        //    if (existingMonkey == null)
        //    {
        //        return NotFound();
        //    }

        //    var monkeyUpdatedDto = _mapper.Map<MonkeyDto>(existingMonkey);

        //    monkeyDelta.Patch(monkeyUpdatedDto);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _mapper.Map(monkeyUpdatedDto, existingMonkey);

        //    await _monkeyShelterRepository.SaveChangesAsync();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}




    }
}