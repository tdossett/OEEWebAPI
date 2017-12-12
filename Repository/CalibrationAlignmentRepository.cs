using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class CalibrationAlignmentRepository : ICalibrationAlignmentRepository
    {
        private OEEContext _context;

        public CalibrationAlignmentRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All Calibration Alignment's
        IEnumerable<CalibrationAlignment> ICalibrationAlignmentRepository.GetAll()
        {
            var calibrationalignment = _context.CalibrationAlignment;

            return calibrationalignment.AsEnumerable();
        }

        // Get an Calibration Alignment
        public CalibrationAlignment Find(int id)
        {
            var calibrationalignment = _context.CalibrationAlignment.Single(o => o.CalibrationAlignmentId == id);

            return calibrationalignment;
        }

        // Add an Calibration Alignment
        public void Add(CalibrationAlignment calibrationalignment)
        {
            _context.CalibrationAlignment.Add(calibrationalignment);
            _context.SaveChanges();
        }

        // Update an Calibration Alignment
        public void Update(CalibrationAlignment calibrationalignment)
        {
            var calibrationalignmentToUpdate = _context.CalibrationAlignment
                .Single(o => o.CalibrationAlignmentId == calibrationalignment.CalibrationAlignmentId);

            if (calibrationalignmentToUpdate != null)
            {
                calibrationalignmentToUpdate.InspectIml = calibrationalignment.InspectIml;
                calibrationalignmentToUpdate.Probe = calibrationalignment.Probe;
                calibrationalignmentToUpdate.SpoolChanges = calibrationalignment.SpoolChanges;
                calibrationalignmentToUpdate.CalibrationDate = calibrationalignment.CalibrationDate;
                _context.SaveChanges();
            }
        }

        // Remove an Calibration Alignment
        public void Remove(int id)
        {
            var calibrationalignmentToRemove = _context.CalibrationAlignment.Single(o => o.CalibrationAlignmentId == id);
            if (calibrationalignmentToRemove != null)
            {
                _context.Remove(calibrationalignmentToRemove);
                _context.SaveChanges();
            }
        }
    }
}
