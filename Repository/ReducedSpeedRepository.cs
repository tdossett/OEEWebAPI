using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class ReducedSpeedRepository : IReducedSpeedRespository
    {
        private OEEContext _context;

        // Constructor
        public ReducedSpeedRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All ReducedSpeed's
        IEnumerable<ReducedSpeed> IReducedSpeedRespository.GetAll()
        {
            var reducedspeed = _context.ReducedSpeed;

            return reducedspeed.AsEnumerable();
        }

        // Get an ReducedSpeed
        public ReducedSpeed Find(int id)
        {
            var reducedspeed = _context.ReducedSpeed.Single(o => o.ReducedSpeedId == id);

            return reducedspeed;
        }

        // Add an ReducedSpeed
        public void Add(ReducedSpeed reducedspeed)
        {
            _context.ReducedSpeed.Add(reducedspeed);
            _context.SaveChanges();
        }

        // Update an ReducedSpeed
        public void Update(ReducedSpeed reducedspeed)
        {
            var reducedspeedToUpdate = _context.ReducedSpeed.Single(o => o.ReducedSpeedId == reducedspeed.ReducedSpeedId);
            if (reducedspeedToUpdate != null)
            {
                reducedspeedToUpdate.ReduceFeedrate = reducedspeed.ReduceFeedrate;
                reducedspeedToUpdate.ReduceSpeedDate = reducedspeed.ReduceSpeedDate;
                _context.SaveChanges();
            }
        }

        // Remove an ReducedSpeed
        public void Remove(int id)
        {
            var reducedspeedToRemove = _context.ReducedSpeed.Single(o => o.ReducedSpeedId == id);
            if (reducedspeedToRemove != null)
            {
                _context.Remove(reducedspeedToRemove);
                _context.SaveChanges();
            }
        }
    }
}
