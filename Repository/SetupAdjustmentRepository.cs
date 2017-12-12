using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class SetupAdjustmentRepository : ISetupAdjustmentRepository
    {
        private OEEContext _context;

        // Constructor
        public SetupAdjustmentRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All SetupAdjustment's
        IEnumerable<SetupAdjustment> ISetupAdjustmentRepository.GetAll()
        {
            var setupadjustment = _context.SetupAdjustment;

            return setupadjustment.AsEnumerable();
        }

        // Get an SetupAdjustment
        public SetupAdjustment Find(int id)
        {
            var setupadjustment = _context.SetupAdjustment.Single(o => o.SetupAdjustmentId == id);

            return setupadjustment;
        }

        // Add an  SetupAdjustment
        public void Add(SetupAdjustment setupadjustment)
        {
            _context.SetupAdjustment.Add(setupadjustment);
            _context.SaveChanges();
        }

        // Update an SetupAdjustment
        public void Update(SetupAdjustment setupadjustment)
        {
            var setupadjustmentToUpdate = _context.SetupAdjustment
                .Single(o => o.SetupAdjustmentId == setupadjustment.SetupAdjustmentId);
            if (setupadjustmentToUpdate != null)
            {
                setupadjustmentToUpdate.AvailabilityId = setupadjustment.AvailabilityId;
                _context.SaveChanges();
            }
        }

        // Remove an SetupAdjustment
        public void Remove(int id)
        {
            var setupadjustmentToRemove = _context.SetupAdjustment.Single(o => o.SetupAdjustmentId == id);
            if (setupadjustmentToRemove != null)
            {
                _context.Remove(setupadjustmentToRemove);
                _context.SaveChanges();
            }
        }
    }
}
