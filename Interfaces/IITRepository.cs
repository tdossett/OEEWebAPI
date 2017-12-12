using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IITRepository
    {
        IEnumerable<It> GetAll();
        It Find(int id);
        void Add(It it);
        void Update(It it);
        void Remove(int id);
    }
}
