using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;
namespace OEEWebAPI.Repository
{
    public class ITRepository : IITRepository
    {
        private OEEContext _context;

        // Constructor
        public ITRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All IT's
        IEnumerable<It> IITRepository.GetAll()
        {
            var it = _context.It;

            return it.AsEnumerable();
        }

        // Get an IT
        public It Find(int id)
        {
            var it = _context.It.Single(o => o.Itid == id);

            return it;
        }

        // Add an IT
        public void Add(It it)
        {
            _context.It.Add(it);
            _context.SaveChanges();
        }

        // Update an IT
        public void Update(It it)
        {
            var itToUpdate = _context.It.Single(o => o.Itid == it.Itid);
            if (itToUpdate != null)
            {
                itToUpdate.Network = it.Network;
                itToUpdate.Server = it.Server;
                itToUpdate.Other = it.Other;
                itToUpdate.Itdate = it.Itdate;
                _context.SaveChanges();
            }
        }

        // Remove an IT
        public void Remove(int id)
        {
            var itToRemove = _context.It.Single(o => o.Itid == id);
            if (itToRemove != null)
            {
                _context.Remove(itToRemove);
                _context.SaveChanges();
            }
        }
    }
}
