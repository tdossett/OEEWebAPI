using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class PersonalUnplannedRepository : IPersonalUnplannedRepository
    {
        private OEEContext _context;

        // Constructor
        public PersonalUnplannedRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All PersonalUnplanned's
        IEnumerable<PersonalUnplanned> IPersonalUnplannedRepository.GetAll()
        {
            var personalunplanned = _context.PersonalUnplanned;

            return personalunplanned.AsEnumerable();
        }

        // Get an PersonalUnplanned
        public PersonalUnplanned Find(int id)
        {
            var personalunplanned = _context.PersonalUnplanned.Single(o => o.PersonalUnplannedId == id);

            return personalunplanned;
        }

        // Add an PersonalUnplanned
        public void Add(PersonalUnplanned personalunplanned)
        {
            _context.PersonalUnplanned.Add(personalunplanned);
            _context.SaveChanges();
        }

        // Update an PersonalUnplanned
        public void Update(PersonalUnplanned personalunplanned)
        {
            var personalunplannedToUpdate = _context.PersonalUnplanned.Single(o => o.PersonalUnplannedId == personalunplanned.PersonalUnplannedId);
            if (personalunplannedToUpdate != null)
            {
                personalunplannedToUpdate.MeetingUnplanned = personalunplanned.MeetingUnplanned;
                personalunplannedToUpdate.OperatorRelief = personalunplanned.OperatorRelief;
                personalunplannedToUpdate.PersonalUnplannedDate = personalunplanned.PersonalUnplannedDate;
                _context.SaveChanges();
            }
        }

        // Remove an PersonalUnplanned
        public void Remove(int id)
        {
            var personalunplannedToRemove = _context.PersonalUnplanned.Single(o => o.PersonalUnplannedId == id);
            if (personalunplannedToRemove != null)
            {
                _context.Remove(personalunplannedToRemove);
                _context.SaveChanges();
            }
        }

    }
}
