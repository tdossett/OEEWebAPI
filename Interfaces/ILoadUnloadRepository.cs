using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface ILoadUnloadRepository
    {
        IEnumerable<LoadUnload> GetAll();
        LoadUnload Find(int id);
        void Add(LoadUnload loadunload);
        void Update(LoadUnload loadunload);
        void Remove(int id);
    }
}
