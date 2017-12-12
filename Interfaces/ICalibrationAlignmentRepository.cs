using System.Collections.Generic;
using OEEWebAPI.Models;

namespace OEEWebAPI.Interfaces
{
    public interface ICalibrationAlignmentRepository
    {
        IEnumerable<CalibrationAlignment> GetAll();
        CalibrationAlignment Find(int id);
        void Add(CalibrationAlignment calibrationalignment);
        void Update(CalibrationAlignment calibrationalignment);
        void Remove(int id);
    }
}
