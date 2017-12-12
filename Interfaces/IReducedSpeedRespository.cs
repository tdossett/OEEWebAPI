using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IReducedSpeedRespository
    {
        IEnumerable<ReducedSpeed> GetAll();
        ReducedSpeed Find(int id);
        void Add(ReducedSpeed reducedspeed);
        void Update(ReducedSpeed reducedspeed);
        void Remove(int id);
    }
}
