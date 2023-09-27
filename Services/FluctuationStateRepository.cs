using MonkeyShelter.Common;
using MonkeyShelter.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MonkeyShelter.Services
{
    public class FluctuationStateRepository : IFluctuationStateRepository
    {

        private readonly MonkeyShelterContext _context;

        public FluctuationStateRepository(MonkeyShelterContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddFluctuation(MonkeyFluctuationState monkeyFluctuationState)
        {
            _context.FluctuationStates.Add(monkeyFluctuationState);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IDictionary<FluctuationState, int> CountForToday()
        {
            DateTime today = DateTime.Today;

            var counts = _context.FluctuationStates
                .Where(e => DbFunctions.TruncateTime(e.CreatedDate) == today)
                .GroupBy(e => e.FluctuationState)
                .Select(g => new
                {
                    EnumValue = g.Key,
                    Count = g.Count()
                })
                .ToDictionary(x => x.EnumValue, x => x.Count);

            return counts;
        }

        public int CountArrivalForToday()
        {
            DateTime today = DateTime.Today;

            var counts = _context.FluctuationStates
                .Where(e => DbFunctions.TruncateTime(e.CreatedDate) == today
                && e.FluctuationState == FluctuationState.Arrived)
                .GroupBy(e => e.FluctuationState)
                .Select(g => g.Count()
                ).FirstOrDefault();
                

            return counts;
        }

        public int CountLeavesForToday()
        {
            DateTime today = DateTime.Today;

            var counts = _context.FluctuationStates
                .Where(e => DbFunctions.TruncateTime(e.CreatedDate) == today
                && e.FluctuationState == FluctuationState.Left)
                .GroupBy(e => e.FluctuationState)
                .Select(g => g.Count()
                ).FirstOrDefault();


            return counts;
        }

    }
}