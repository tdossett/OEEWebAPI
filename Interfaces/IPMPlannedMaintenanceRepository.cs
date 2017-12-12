using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IPMPlannedMaintenanceRepository
    {
        IEnumerable<PmplannedMaintenance> GetAll();
        PmplannedMaintenance Find(int id);
        void Add(PmplannedMaintenance pmplannedmaintenance);
        void Update(PmplannedMaintenance pmplannedmaintenance);
        void Remove(int id);
    }
}
