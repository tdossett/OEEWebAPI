using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IPerformanceEfficiencyRepository
    {
        IEnumerable<PerformanceEfficiency> GetAll();
        PerformanceEfficiency Find(int id);
        void Add(PerformanceEfficiency performanceefficiency);
        void Update(PerformanceEfficiency performanceefficiency);
        void Remove(int id);
    }
}
