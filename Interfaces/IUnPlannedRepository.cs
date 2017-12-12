using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IUnPlannedRepository
    {
        IEnumerable<UnPlanned> GetAll();
        UnPlanned Find(int id);
        void Add(UnPlanned unplanned);
        void Update(UnPlanned unplanned);
        void Remove(int id);
    }
}
