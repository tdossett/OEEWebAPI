using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class PersonalPlannedRepository : IPersonalPlannedRepository
    {
        private OEEContext _context;

        // Constructor
        public PersonalPlannedRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All PersonalPlanned's
        IEnumerable<PersonalPanned> IPersonalPlannedRepository.GetAll()
        {
            var personalplanned = _context.PersonalPanned;

            return personalplanned.AsEnumerable();
        }

        // Get an PerosnalPlanned
        public PersonalPanned Find(int id)
        {
            var personalplanned = _context.PersonalPanned.Single(o => o.PersonalPannedId == id);

            return personalplanned;
        }

        // Add an PersonalPlanned
        public void Add(PersonalPanned personalplanned)
        {
            _context.PersonalPanned.Add(personalplanned);
            _context.SaveChanges();
        }

        // Update an PersonalPlanned
        public void Update(PersonalPanned personalplanned)
        {
            var personalplannedToUpdate = _context.PersonalPanned.Single(o => o.PersonalPannedId == personalplanned.PersonalPannedId);
            if (personalplannedToUpdate != null)
            {
                personalplannedToUpdate.Break = personalplanned.Break;
                personalplannedToUpdate.MeetingPlanned = personalplanned.MeetingPlanned;
                personalplannedToUpdate.ShiftChanged = personalplanned.ShiftChanged;
                personalplannedToUpdate.Training = personalplanned.Training;
                personalplannedToUpdate.PlannedDate = personalplanned.PlannedDate;
                _context.SaveChanges();
            }
        }

        // Remove an PersonalPlanned
        public void Remove(int id)
        {
            var personalplannedToRemove = _context.Oee.Single(o => o.Oeeid == id);
            if (personalplannedToRemove != null)
            {
                _context.Remove(personalplannedToRemove);
                _context.SaveChanges();
            }
        }
    }
}
