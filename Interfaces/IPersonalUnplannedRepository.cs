using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IPersonalUnplannedRepository
    {
        IEnumerable<PersonalUnplanned> GetAll();
        PersonalUnplanned Find(int id);
        void Add(PersonalUnplanned personalunplanned);
        void Update(PersonalUnplanned personalunplanned);
        void Remove(int id);
    }
}
