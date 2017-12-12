using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IPersonalPlannedRepository
    {
        IEnumerable<PersonalPanned> GetAll();
        PersonalPanned Find(int id);
        void Add(PersonalPanned personalplanned);
        void Update(PersonalPanned personalplanned);
        void Remove(int id);
    }
}
