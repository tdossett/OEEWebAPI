using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IOEERepository
    {
        IEnumerable<Oee> GetAll();
        Oee Find(int id);
        void Add(Oee oee);
        void Update(Oee oee);
        void Remove(int id);
    }
}
