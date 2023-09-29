using MonkeyShelter.Common;
using MonkeyShelter.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonkeyShelter.Services
{
    public interface IFluctuationStateRepository
    {
        void AddFluctuation(MonkeyFluctuationState monkeyFluctuationState);
        Task SaveChangesAsync();

        IDictionary<FluctuationState, int> CountForToday();

        int CountArrivalForToday();

        int CountLeavesForToday();
    }
}