using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class OEERepository : IOEERepository
    {
        private OEEContext _context;

        // Constructor
        public OEERepository(OEEContext context)
        {
            _context = context;
        }

        // Get All Oee's
        IEnumerable<Oee> IOEERepository.GetAll()
        {
            var oee = _context.Oee;

            return oee.AsEnumerable();
        }

        // Get an Oee
        public Oee Find(int id)
        {
            var oee = _context.Oee.Single(o => o.Oeeid == id);

            return oee;
        }

        // Add an Oee
        public void Add(Oee oee)
        {
            _context.Oee.Add(oee);
            _context.SaveChanges();
        }

        // Update an Oee
        public void Update(Oee oee)
        {
            var oeeToUpdate = _context.Oee.Single(o => o.Oeeid == oee.Oeeid);
            if (oeeToUpdate != null)
            {
                oeeToUpdate.Oeename = oee.Oeename;
                _context.SaveChanges();
            }
        }

        // Remove an Oee
        public void Remove(int id)
        {
            var oeeToRemove = _context.Oee.Single(o => o.Oeeid == id);
            if (oeeToRemove != null)
            {
                _context.Remove(oeeToRemove);
                _context.SaveChanges();
            }
        }

    }
}
