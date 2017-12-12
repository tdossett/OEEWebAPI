using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IIdlingMinorStoppageRepository
    {
        IEnumerable<IdlingMinorStoppage> GetAll();
        IdlingMinorStoppage Find(int id);
        void Add(IdlingMinorStoppage idlingminorstoppage);
        void Update(IdlingMinorStoppage idlingminorstoppage);
        void Remove(int id);
    }
}
