using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        private OEEContext _context;

        // Constructor
        public AvailabilityRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All Availability's
        IEnumerable<Availability> IAvailabilityRepository.GetAll()
        {
            var availability = _context.Availability;

            return availability.AsEnumerable();
        }

        // Get an Availability
        public Availability Find(int id)
        {
            var availability = _context.Availability.Single(o => o.AvailabilityId == id);

            return availability;
        }

        // Add an Availability
        public void Add(Availability availability)
        {
            _context.Availability.Add(availability);
            _context.SaveChanges();
        }

        // Update an Availability
        public void Update(Availability availability)
        {
            var availabilityToUpdate = _context.Availability.Single(o => o.AvailabilityId == availability.AvailabilityId);
            if (availabilityToUpdate != null)
            {
                availabilityToUpdate.UnPlannedId = availability.UnPlannedId;
                _context.SaveChanges();
            }
        }

        // Remove an Avaialbility
        public void Remove(int id)
        {
            var availabilityToRemove = _context.Availability.Single(o => o.AvailabilityId == id);
            if (availabilityToRemove != null)
            {
                _context.Remove(availabilityToRemove);
                _context.SaveChanges();
            }
        }
    }
}
