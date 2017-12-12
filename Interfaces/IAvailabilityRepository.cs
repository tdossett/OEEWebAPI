using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IAvailabilityRepository
    {
        IEnumerable<Availability> GetAll();
        Availability Find(int id);
        void Add(Availability availability);
        void Update(Availability availability);
        void Remove(int id);
    }
}
