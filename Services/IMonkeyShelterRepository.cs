using MonkeyShelter.Entities;
using MonkeyShelter.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonkeyShelter.Services
{
    public interface IMonkeyShelterRepository
    {
        Task<IEnumerable<Monkey>> GetMonkeysAsync();
        Task<Monkey> GetMonkeyAsync(string monkeyId);

        List<SpeciesCountDto> GetSpeciesWithCount();

        List<SpeciesCountDto> GetSpeciesByDateRange(DateTime startDate, DateTime endDate);

        void AddMonkey(Monkey monkey);
        void DeleteMonkey(Monkey monkey);
        void UpdateMonkey(Monkey monkey);
        Task SaveChangesAsync();
    }
}