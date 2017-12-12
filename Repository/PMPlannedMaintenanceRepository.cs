using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class PMPlannedMaintenanceRepository : IPMPlannedMaintenanceRepository
    {
        private OEEContext _context;

        // Constructor
        public PMPlannedMaintenanceRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All PMPlannedMaintenance's
        IEnumerable<PmplannedMaintenance> IPMPlannedMaintenanceRepository.GetAll()
        {
            var pmplannedmaintenance = _context.PmplannedMaintenance;

            return pmplannedmaintenance.AsEnumerable();
        }

        // Get an PMPlannedMaintenance
        public PmplannedMaintenance Find(int id)
        {
            var oee = _context.PmplannedMaintenance.Single(o => o.PmplannedMaintenanceId == id);

            return oee;
        }

        // Add an PMPlannedMaintenance
        public void Add(PmplannedMaintenance pmplannedmaintenance)
        {
            _context.PmplannedMaintenance.Add(pmplannedmaintenance);
            _context.SaveChanges();
        }

        // Update an PMPlannedMaintenance
        public void Update(PmplannedMaintenance pmplannedmaintenance)
        {
            var pmplannedmaintenanceToUpdate = _context.PmplannedMaintenance
                .Single(o => o.PmplannedMaintenanceId == pmplannedmaintenance.PmplannedMaintenanceId);
            if (pmplannedmaintenanceToUpdate != null)
            {
                pmplannedmaintenanceToUpdate.PlannedMaintenace = pmplannedmaintenance.PlannedMaintenace;
                pmplannedmaintenanceToUpdate.Tpm = pmplannedmaintenance.Tpm;
                pmplannedmaintenanceToUpdate.Calibration = pmplannedmaintenance.Calibration;
                pmplannedmaintenanceToUpdate.Testing = pmplannedmaintenance.Testing;
                pmplannedmaintenanceToUpdate.Other = pmplannedmaintenance.Other;
                pmplannedmaintenanceToUpdate.PmplannedMaintenanceDate = pmplannedmaintenance.PmplannedMaintenanceDate;
                _context.SaveChanges();
            }
        }

        // Remove an PMPlannedMaintenance
        public void Remove(int id)
        {
            var pmplannedmaintenanceToRemove = _context.PmplannedMaintenance.Single(o => o.PmplannedMaintenanceId == id);
            if (pmplannedmaintenanceToRemove != null)
            {
                _context.Remove(pmplannedmaintenanceToRemove);
                _context.SaveChanges();
            }
        }
    }
}
