using MonkeyShelter.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonkeyShelter.Services
{
    public interface IMonkeyShelterRepository
    {

        Task<IEnumerable<Monkey>> GetMonkeysAsync();
        //Task<Monkey> GetMonkeyAsync(string  monkeyId);
    }
}