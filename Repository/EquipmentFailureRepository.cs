using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class EquipmentFailureRepository : IEquipmentFailureRepository
    {
        private OEEContext _context;

        // Constructor
        public EquipmentFailureRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All EquipmentFailure's
        IEnumerable<EquipmentFailure> IEquipmentFailureRepository.GetAll()
        {
            var equipmentfailure = _context.EquipmentFailure;

            return equipmentfailure.AsEnumerable();
        }

        // Get an EquipmentFailure
        public EquipmentFailure Find(int id)
        {
            var equipmentfailure = _context.EquipmentFailure.Single(o => o.EquipmentFailureId == id);

            return equipmentfailure;
        }

        // Add an EquipmentFailure
        public void Add(EquipmentFailure equipmentfailure)
        {
            _context.EquipmentFailure.Add(equipmentfailure);
            _context.SaveChanges();
        }

        // Update an EquipmentFailure
        public void Update(EquipmentFailure equipmentfailure)
        {
            var equipmentfailureToUpdate = _context.EquipmentFailure
                .Single(o => o.EquipmentFailureId == equipmentfailure.EquipmentFailureId);
            if (equipmentfailureToUpdate != null)
            {
                equipmentfailureToUpdate.AvailabilityId = equipmentfailure.EquipmentFailureId;
                _context.SaveChanges();
            }
        }

        // Remove an EquipmentFailure
        public void Remove(int id)
        {
            var equipmentfailureToRemove = _context.EquipmentFailure.Single(o => o.EquipmentFailureId == id);
            if (equipmentfailureToRemove != null)
            {
                _context.Remove(equipmentfailureToRemove);
                _context.SaveChanges();
            }
        }

    }
}
