using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> GetAll();
        Material Find(int id);
        void Add(Material material);
        void Update(Material material);
        void Remove(int id);
    }
}
