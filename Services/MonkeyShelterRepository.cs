using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.WebPages;
using MonkeyShelter.Entities;
using MonkeyShelter.Models;

namespace MonkeyShelter.Services
{
    public class MonkeyShelterRepository : IMonkeyShelterRepository
    {
        private readonly MonkeyShelterContext _context;

        public MonkeyShelterRepository(MonkeyShelterContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Monkey>> GetMonkeysAsync()
        {
            return await _context.Monkeys.ToListAsync();
        }

        public async Task<Monkey> GetMonkeyAsync(string monkeyId)
        {
            return await _context.Monkeys
                .Where(c => c.Id == monkeyId).FirstOrDefaultAsync();
        }

        public List<SpeciesCountDto> GetSpeciesWithCount()
        {
            return _context.Monkeys
                .GroupBy(c => c.Species)
                .Select(g => new SpeciesCountDto
                {
                Species = g.Key,
                    Count = g.Count()
                }).ToList();
        }

        public List<SpeciesCountDto> GetSpeciesByDateRange(DateTime startDate, DateTime endDate)
        {
            
            var entities = _context.Monkeys.ToList();

            List<Monkey> filteredEntities = new List<Monkey>();
            foreach (var entity in entities)
            {
                if (DateTime.TryParse(entity.Registered, out DateTime registeredDate))
                {
                    
                    if (registeredDate.Date >= startDate.Date && registeredDate.Date <= endDate.Date)
                    {
                        filteredEntities.Add(entity);
                    }
                }
            }

            var grouped = filteredEntities.GroupBy(c => c.Species)
                .Select(g => new SpeciesCountDto
                {
                    Species = g.Key,
                    Count = g.Count()
                }).ToList();

            return grouped;
        }


        public void AddMonkey(Monkey monkey)
        {
            _context.Monkeys.Add(monkey);
        }

        public void DeleteMonkey(Monkey monkey)
        {
            if (_context.Entry(monkey).State == EntityState.Detached)
            {
                _context.Monkeys.Attach(monkey);
            }
            _context.Monkeys.Remove(monkey);
        }

        public void UpdateMonkey(Monkey monkey)
        {
            _context.Entry(monkey).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}