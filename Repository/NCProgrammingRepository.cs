using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class NCProgrammingRepository : INCProgrammingRepository
    {
        private OEEContext _context;

        // Constructor
        public NCProgrammingRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All NCProgramming's
        IEnumerable<Ncprogramming> INCProgrammingRepository.GetAll()
        {
            var ncprogramming = _context.Ncprogramming;

            return ncprogramming.AsEnumerable();
        }

        // Get an NCProgamming
        public Ncprogramming Find(int id)
        {
            var ncprogamming = _context.Ncprogramming.Single(o => o.NcprogrammingId == id);

            return ncprogamming;
        }

        // Add an NCProgramming
        public void Add(Ncprogramming ncprogamming)
        {
            _context.Ncprogramming.Add(ncprogamming);
            _context.SaveChanges();
        }

        // Update an NCProgamming
        public void Update(Ncprogramming ncprogamming)
        {
            var ncprogammingToUpdate = _context.Ncprogramming.Single(o => o.NcprogrammingId == ncprogamming.NcprogrammingId);
            if (ncprogammingToUpdate != null)
            {
                ncprogammingToUpdate.NcprogramIssue = ncprogamming.NcprogramIssue;
                ncprogammingToUpdate.Other = ncprogamming.Other;
                ncprogammingToUpdate.NcprogrammingDate = ncprogamming.NcprogrammingDate;
                _context.SaveChanges();
            }
        }

        // Remove an NCProgramming
        public void Remove(int id)
        {
            var ncprogrammingToRemove = _context.Ncprogramming.Single(o => o.NcprogrammingId == id);
            if (ncprogrammingToRemove != null)
            {
                _context.Remove(ncprogrammingToRemove);
                _context.SaveChanges();
            }
        }


    }
}
