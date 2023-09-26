using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
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