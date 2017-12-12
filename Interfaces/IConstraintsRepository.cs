using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IConstraintsRepository
    {
        IEnumerable<Constraints> GetAll();
        Constraints Find(int id);
        void Add(Constraints constraints);
        void Update(Constraints constraints);
        void Remove(int id);
    }
}
