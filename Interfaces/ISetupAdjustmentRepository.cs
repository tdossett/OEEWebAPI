using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface ISetupAdjustmentRepository
    {
        IEnumerable<SetupAdjustment> GetAll();
        SetupAdjustment Find(int id);
        void Add(SetupAdjustment setupadjustment);
        void Update(SetupAdjustment setupadjustment);
        void Remove(int id);
    }
}
