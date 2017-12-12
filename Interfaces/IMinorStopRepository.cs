using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface IMinorStopRepository
    {
        IEnumerable<MinorStop> GetAll();
        MinorStop Find(int id);
        void Add(MinorStop minorstop);
        void Update(MinorStop minorstop);
        void Remove(int id);
    }
}
