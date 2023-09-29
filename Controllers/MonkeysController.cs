using AutoMapper;
using Castle.Core.Logging;
using MonkeyShelter.Entities;
using MonkeyShelter.Models;
using MonkeyShelter.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace MonkeyShelter.Controllers
{
    public class MonkeysController : ApiController
    {

        private readonly IMapper _mapper;
        private readonly IMonkeyShelterRepository _monkeyShelterRepository;
        private readonly IFluctuationStateRepository _fluctuationStateRepository;
        private readonly ILogger _logger;

        public MonkeysController(IMapper mapper, IMonkeyShelterRepository monkeyShelterRepository, IFluctuationStateRepository fluctuationStateRepository, ILogger logger)
        {
            _mapper = mapper;
            _monkeyShelterRepository = monkeyShelterRepository;
            _fluctuationStateRepository = fluctuationStateRepository;
            _logger = logger;
        }

        //GET ALL ASYNC : api/Monkeys/
        [HttpGet]
        [ResponseType(typeof(Monkey))]
        public async Task<IHttpActionResult> GetMonkeysAsync()
        {

            var monkeyEntities = await _monkeyShelterRepository.GetMonkeysAsync();
            return Ok(_mapper.Map<IEnumerable<MonkeyDto>>(monkeyEntities));

        }

        //GET MONKEY BY ID ASYNC: api/Monkeys/id
        [HttpGet]
        [ResponseType(typeof(Monkey))]
        public async Task<IHttpActionResult> GetMonkeyAsync(string id)
        {

            var monkeyEntity = await _monkeyShelterRepository.GetMonkeyAsync(id);
            if (monkeyEntity == null)
            {
                _logger.Error(
                    $"Monkey with id {id} wasn't found.");
                return NotFound();
            }
            return Ok(_mapper.Map<MonkeyDto>(monkeyEntity));

        }

        //DELETE: api/Monkeys/id
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteMonkey(string id)
        {
            var item = await _monkeyShelterRepository.GetMonkeyAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var countLeaves = _fluctuationStateRepository.CountLeavesForToday();
            var countArrivals = _fluctuationStateRepository.CountArrivalForToday();
            if (countLeaves >= 5)
            {
                return BadRequest("Not allowed to remove more than 5 monkeys per day.");
            }

            else if ((countLeaves - countArrivals) >= 2)
            {
                return BadRequest("Not allowed to remove more monkeys until you add some.");
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
        [HttpPost]
        public async Task<IHttpActionResult> AddMonkey(MonkeyCreateDto monkeyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var count = _fluctuationStateRepository.CountArrivalForToday();
            if (count >= 7)
            {
                return BadRequest("Not allowed to add more than 7 monkeys per day.");
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

        //PUT: api/Monkeys/id
        [HttpPut]
        public async Task<IHttpActionResult> UpdateMonkeyWeight(string id, int weight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

        //GET: api/species
        [HttpGet]
        [Route("api/species")]
        public IHttpActionResult GetSpecies(DateTime? startDate = null, DateTime? endDate = null)
        {
            if (startDate.HasValue && endDate.HasValue)
            {
                return Ok(_monkeyShelterRepository.GetSpeciesByDateRange(startDate.Value, endDate.Value));
            }

            return Ok(_monkeyShelterRepository.GetSpeciesWithCount());

        }

    }
}