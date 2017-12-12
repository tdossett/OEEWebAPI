using System.Collections.Generic;
using OEEWebAPI.Models;
namespace OEEWebAPI.Interfaces
{
    public interface IPlannedDowntimeRepository
    {
        IEnumerable<PlannedDowntime> GetAll();
        PlannedDowntime Find(int id);
        void Add(PlannedDowntime planneddowntime);
        void Update(PlannedDowntime planneddowntime);
        void Remove(int id);
    }
}
