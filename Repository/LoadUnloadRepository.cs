using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class LoadUnloadRepository : ILoadUnloadRepository
    {
        private OEEContext _context;

        // Constructor
        public LoadUnloadRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All LoadUnload's
        IEnumerable<LoadUnload> ILoadUnloadRepository.GetAll()
        {
            var loadunload = _context.LoadUnload;

            return loadunload.AsEnumerable();
        }

        // Get an LoadUnload
        public LoadUnload Find(int id)
        {
            var loadunload = _context.LoadUnload.Single(o => o.LoadUnloadId == id);

            return loadunload;
        }

        // Add an LoadUnload
        public void Add(LoadUnload loadunload)
        {
            _context.LoadUnload.Add(loadunload);
            _context.SaveChanges();
        }

        // Update an LoadUnload
        public void Update(LoadUnload loadunload)
        {
            var loadunloadToUpdate = _context.LoadUnload.Single(o => o.LoadUnloadId == loadunload.LoadUnloadId);
            if (loadunloadToUpdate != null)
            {
                loadunloadToUpdate.Load = loadunload.Load;
                loadunloadToUpdate.Unload = loadunload.Unload;
                loadunloadToUpdate.Debag = loadunload.Debag;
                loadunloadToUpdate.InterimClean = loadunload.InterimClean;
                loadunloadToUpdate.PreClean = loadunload.PreClean;
                loadunloadToUpdate.PostClean = loadunload.PostClean;
                loadunloadToUpdate.AwaitingProgram = loadunload.AwaitingProgram;
                loadunloadToUpdate.LoadUnloadDate = loadunload.LoadUnloadDate;
                _context.SaveChanges();
            }
        }

        // Remove an LoadUnload
        public void Remove(int id)
        {
            var loadunloadToRemove = _context.LoadUnload.Single(o => o.LoadUnloadId == id);
            if (loadunloadToRemove != null)
            {
                _context.Remove(loadunloadToRemove);
                _context.SaveChanges();
            }
        }
    }
}
