using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IMachineRepository
    {

        IEnumerable<Machine> GetAll();
        Machine Find(int id);
        void Add(Machine machine);
        void Update(Machine machine);
        void Remove(int id);
    }
}
