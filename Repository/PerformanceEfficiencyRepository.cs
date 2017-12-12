using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;
namespace OEEWebAPI.Repository
{
    public class PerformanceEfficiencyRepository : IPerformanceEfficiencyRepository
    {
        private OEEContext _context;

        // Constructor
        public PerformanceEfficiencyRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All PerformanceEfficiency's
        IEnumerable<PerformanceEfficiency> IPerformanceEfficiencyRepository.GetAll()
        {
            var performanceefficiency = _context.PerformanceEfficiency;

            return performanceefficiency.AsEnumerable();
        }

        // Get an PerformanceEfficiency
        public PerformanceEfficiency Find(int id)
        {
            var performanceefficiency = _context.PerformanceEfficiency.Single(o => o.PerformanceEfficiencyId == id);

            return performanceefficiency;
        }

        // Add an PerformanceEfficiency
        public void Add(PerformanceEfficiency performanceefficiency)
        {
            _context.PerformanceEfficiency.Add(performanceefficiency);
            _context.SaveChanges();
        }

        // Update an PerformanceEfficiency
        public void Update(PerformanceEfficiency performanceefficiency)
        {
            var performanceefficiencyToUpdate = _context.PerformanceEfficiency
                .Single(o => o.PerformanceEfficiencyId == performanceefficiency.PerformanceEfficiencyId);
            if (performanceefficiencyToUpdate != null)
            {
                performanceefficiencyToUpdate.UnPlannedId = performanceefficiency.UnPlannedId;
                _context.SaveChanges();
            }
        }

        // Remove an PerformanceEfficiency
        public void Remove(int id)
        {
            var performanceefficiencyToRemove = _context.PerformanceEfficiency.Single(o => o.PerformanceEfficiencyId == id);
            if (performanceefficiencyToRemove != null)
            {
                _context.Remove(performanceefficiencyToRemove);
                _context.SaveChanges();
            }
        }

    }
}
