using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class MinorStopRepository : IMinorStopRepository
    {
        private OEEContext _context;

        // Constructor
        public MinorStopRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All MinorStop's
        IEnumerable<MinorStop> IMinorStopRepository.GetAll()
        {
            var minorstop = _context.MinorStop;

            return minorstop.AsEnumerable();
        }

        // Get an MinorStop
        public MinorStop Find(int id)
        {
            var minorstop = _context.MinorStop.Single(o => o.MinorStopId == id);

            return minorstop;
        }

        // Add an MinorStop
        public void Add(MinorStop minorstop)
        {
            _context.MinorStop.Add(minorstop);
            _context.SaveChanges();
        }

        // Update an MinorStop
        public void Update(MinorStop minorstop)
        {
            var minorstopToUpdate = _context.MinorStop.Single(o => o.MinorStopId == minorstop.MinorStopId);
            if (minorstopToUpdate != null)
            {
                minorstopToUpdate._25minute = minorstop._25minute;
                minorstopToUpdate.MinorStopDate = minorstop.MinorStopDate;
                _context.SaveChanges();
            }
        }

        // Remove an MinorStop
        public void Remove(int id)
        {
            var minorstopToRemove = _context.MinorStop.Single(o => o.MinorStopId == id);
            if (minorstopToRemove != null)
            {
                _context.Remove(minorstopToRemove);
                _context.SaveChanges();
            }
        }

    }
}
