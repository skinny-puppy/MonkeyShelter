using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using MonkeyShelter.Entities;

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

        //public async Task<Monkey> GetMonkeyAsync(string monkeyId)
        //{
        //    return await _context.Monkeys
        //        .Where(c => c.Id == monkeyId).FirstOrDefaultAsync();
        //}
    }
}