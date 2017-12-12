using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class PlannedDowntimeRepository : IPlannedDowntimeRepository
    {
        private OEEContext _context;

        // Constructor
        public PlannedDowntimeRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All PlannedDowntime's
        IEnumerable<PlannedDowntime> IPlannedDowntimeRepository.GetAll()
        {
            var planneddowntime = _context.PlannedDowntime;

            return planneddowntime.AsEnumerable();
        }

        // Get an PlannedDowntime
        public PlannedDowntime Find(int id)
        {
            var planneddowntime = _context.PlannedDowntime.Single(o => o.PlannedDowntimeId == id);

            return planneddowntime;
        }

        // Add an PlannedDowntime
        public void Add(PlannedDowntime planneddowntime)
        {
            _context.PlannedDowntime.Add(planneddowntime);
            _context.SaveChanges();
        }

        // Update an PlannedDowntime
        public void Update(PlannedDowntime planneddowntime)
        {
            var planneddowntimeToUpdate = _context.PlannedDowntime.Single(o => o.PlannedDowntimeId == planneddowntime.PlannedDowntimeId);
            if (planneddowntimeToUpdate != null)
            {
                planneddowntimeToUpdate.NoWorkScheduled = planneddowntime.NoWorkScheduled;
                planneddowntimeToUpdate.PlannedDownTimeDate = planneddowntime.PlannedDownTimeDate;
                _context.SaveChanges();
            }
        }

        // Remove an PlannedDowntime
        public void Remove(int id)
        {
            var planneddowntimeToRemove = _context.PlannedDowntime.Single(o => o.PlannedDowntimeId == id);
            if (planneddowntimeToRemove != null)
            {
                _context.Remove(planneddowntimeToRemove);
                _context.SaveChanges();
            }
        }
    }
}
