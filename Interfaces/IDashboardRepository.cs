using System.Collections.Generic;
using OEEWebAPI.ViewModels;
namespace OEEWebAPI.Interfaces
{
    public interface IDashboardRepository
    {
        // Planned
        IEnumerable<VMPlanned> GetAllPlanned();
        VMPlanned FindPlan(int id);

        // EquipmentFailure
        IEnumerable<VMUnPlannedAvailabilityEquipmentFailure> GetAllEquipmentFailure();
        VMUnPlannedAvailabilityEquipmentFailure FindEquipmentFailure(int id);

        // IdlingMinorStoppage
        IEnumerable<VMUnPlannedPerformanceEfficencyIdlingMinorStoppage> GetAllIdlingMinorStoppage();
        VMUnPlannedPerformanceEfficencyIdlingMinorStoppage FindIdlingMinorStoppage(int id);

        // SetupAdjustment
        IEnumerable<VMUnPlannedAvailabilitySetupAdjustment> GetAllSetupAdjustment();
        VMUnPlannedAvailabilitySetupAdjustment FindSetupAdjustment(int id);

        // ReducedSpeed
        IEnumerable<VMUnPlannedPerformanceEfficencyIdlingReducedSpeed> GetAllReducedSpeed();
        VMUnPlannedPerformanceEfficencyIdlingReducedSpeed FindReducedSpeed(int id);








    }
}
