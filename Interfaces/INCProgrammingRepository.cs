using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface INCProgrammingRepository
    {
        IEnumerable<Ncprogramming> GetAll();
        Ncprogramming Find(int id);
        void Add(Ncprogramming ncprogramming);
        void Update(Ncprogramming ncprogramming);
        void Remove(int id);
    }
}
