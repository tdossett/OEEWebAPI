using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IPlannedRepository
    {
        IEnumerable<Planned> GetAll();
        Planned Find(int id);
        void Add(Planned planned);
        void Update(Planned planned);
        void Remove(int id);
    }
}
