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
using System.Web.Mvc;

namespace MonkeyShelter.Controllers
{
    public class MonkeysController : ApiController
    {

        private readonly IMonkeyShelterRepository _monkeyShelterRepository;
        //private readonly IMapper _mapper;
        public MonkeysController(IMonkeyShelterRepository repo)
        {
            _monkeyShelterRepository = repo;
            //_mapper = mapper;
        }


        //GET ASYNC
        [ResponseType(typeof(Monkey))]
        public async Task<IHttpActionResult> GetMonkeysAsync()
        {

            var monkeyEntities = await _monkeyShelterRepository.GetMonkeysAsync();
            return Ok(monkeyEntities);

        }


        //[ResponseType(typeof(Monkey))]
        //public async Task<IHttpActionResult> GetMonkeyAsync(string id)
        //{

        //    var monkeyEntity = await _monkeyShelterRepository.GetMonkeyAsync(id);
        //    return Ok(_mapper.Map<MonkeyDto>(monkeyEntity));

        //}


        

        // GET: api/Monkeys
        //public IQueryable<Monkey> GetMonkeys()
        //{
        //    return db.Monkeys;
        //}

         //GET: api/Monkeys/5
        //[ResponseType(typeof(Monkey))]
        //public async Task<IHttpActionResult> GetMonkey(string id)
        //{
        //    Monkey monkey = await db.Monkeys.FindAsync(id);
        //    if (monkey == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(monkey);
        //}

        /*

        // PUT: api/Monkeys/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMonkey(string id, Monkey monkey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monkey.Id)
            {
                return BadRequest();
            }

            db.Entry(monkey).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonkeyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Monkeys
        [ResponseType(typeof(Monkey))]
        public async Task<IHttpActionResult> PostMonkey(Monkey monkey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Monkeys.Add(monkey);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MonkeyExists(monkey.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = monkey.Id }, monkey);
        }

        // DELETE: api/Monkeys/5
        [ResponseType(typeof(Monkey))]
        public async Task<IHttpActionResult> DeleteMonkey(string id)
        {
            Monkey monkey = await db.Monkeys.FindAsync(id);
            if (monkey == null)
            {
                return NotFound();
            }

            db.Monkeys.Remove(monkey);
            await db.SaveChangesAsync();

            return Ok(monkey);
        }
        */

        
    }
}