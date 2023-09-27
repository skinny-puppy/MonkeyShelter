using MonkeyShelter.Common;
using MonkeyShelter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

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