using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using OEEWebAPI.ViewModels;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private OEEContext _context;

        // Constructor
        public DashboardRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All Planned
        IEnumerable<VMPlanned> IDashboardRepository.GetAllPlanned()
        {
            var result = (from a in _context.Oee
                join b in _context.Planned on a.Oeeid equals b.Oeeid
                join c in _context.PmplannedMaintenance on b.PlannedId equals c.PlannedId
                join d in _context.PersonalPanned on b.PlannedId equals d.PlannedId
                join e in _context.PlannedDowntime on b.PlannedId equals e.PlannedId

                select new VMPlanned
                {
                    Oeeid = a.Oeeid
                    ,PlannedId = b.PlannedId
                    ,PmplannedMaintenanceId = c.PmplannedMaintenanceId
                    ,PersonalPannedId = d.PersonalPannedId
                    ,PlannedDowntimeId = e.PlannedDowntimeId
                    ,PlannedMaintenace = c.PlannedMaintenace
                    ,Tpm = c.Tpm
                    ,Calibration = c.Calibration
                    ,Testing = c.Testing
                    ,Other = c.Other
                    ,PmplannedMaintenanceDate = c.PmplannedMaintenanceDate
                    ,Break = d.Break
                    ,MeetingPlanned = d.MeetingPlanned
                    ,ShiftChanged = d.ShiftChanged
                    ,Training = d.Training
                    ,PlannedDate = d.PlannedDate
                    ,NoWorkScheduled = e.NoWorkScheduled
                    ,PlannedDownTimeDate = e.PlannedDownTimeDate

                }).ToList();

            return result.AsEnumerable();
        }

        // Get a Plan
        public VMPlanned FindPlan(int id)
        {
            var result = (from a in _context.Oee
                          join b in _context.Planned on a.Oeeid equals b.Oeeid
                          join c in _context.PmplannedMaintenance on b.PlannedId equals c.PlannedId
                          join d in _context.PersonalPanned on b.PlannedId equals d.PlannedId
                          join e in _context.PlannedDowntime on b.PlannedId equals e.PlannedId
                          where a.Oeeid == id
                          select new VMPlanned
                          {
                              Oeeid = a.Oeeid
                              ,
                              PlannedId = b.PlannedId
                              ,
                              PmplannedMaintenanceId = c.PmplannedMaintenanceId
                              ,
                              PersonalPannedId = d.PersonalPannedId
                              ,
                              PlannedDowntimeId = e.PlannedDowntimeId
                              ,
                              PlannedMaintenace = c.PlannedMaintenace
                              ,
                              Tpm = c.Tpm
                              ,
                              Calibration = c.Calibration
                              ,
                              Testing = c.Testing
                              ,
                              Other = c.Other
                              ,
                              PmplannedMaintenanceDate = c.PmplannedMaintenanceDate
                              ,
                              Break = d.Break
                              ,
                              MeetingPlanned = d.MeetingPlanned
                              ,
                              ShiftChanged = d.ShiftChanged
                              ,
                              Training = d.Training
                              ,
                              PlannedDate = d.PlannedDate
                              ,
                              NoWorkScheduled = e.NoWorkScheduled
                              ,
                              PlannedDownTimeDate = e.PlannedDownTimeDate

                          }).SingleOrDefault();

            return result;
        }

        // Get All Equipment Failure
        IEnumerable<VMUnPlannedAvailabilityEquipmentFailure> IDashboardRepository.GetAllEquipmentFailure()
        {
            var result = (from a in _context.Oee
                          join b in _context.UnPlanned on a.Oeeid equals b.Oeeid
                          join c in _context.Availability on b.UnPlannedId equals c.UnPlannedId
                          join d in _context.EquipmentFailure on c.AvailabilityId equals d.AvailabilityId
                          join e in _context.CartMhe on d.EquipmentFailureId equals e.EquipmentFailureId
                          join f in _context.Machine on e.EquipmentFailureId equals f.EquipmentFailureId
                          join g in _context.It on f.EquipmentFailureId equals g.EquipmentFailureId

                          select new VMUnPlannedAvailabilityEquipmentFailure
                          {
                              Oeeid = a.Oeeid
                              ,UnPlannedId = b.UnPlannedId
                              ,AvailabilityId = c.AvailabilityId
                              ,EquipmentFailureId = d.EquipmentFailureId
                              ,CartMheid = e.CartMheid
                              ,MachineId = f.MachineId
                              ,Itid = g.Itid
                              ,DeadBattery = e.DeadBattery
                              ,BrokenWheels = e.BrokenWheels
                              ,TurntableMalfunction = e.TurntableMalfunction
                              ,CartMHEOther = e.Other
                              ,Oltissue = f.Oltissue
                              ,CutterIssue = f.CutterIssue
                              ,BrokenBulb = f.BrokenBulb
                              ,BrokenSplice = f.BrokenSplice
                              ,Electrical = f.Electrical
                              ,FaultStop = f.FaultStop
                              ,IrheaterError = f.IrheaterError
                              ,FiberDelivery = f.FiberDelivery
                              ,CutterBlade = f.CutterBlade
                              ,ServoFailure = f.ServoFailure
                              ,Tensioner = f.Tensioner
                              ,AxisFailure = f.AxisFailure
                              ,ClampIssue = f.ClampIssue
                              ,ClampPistonFailure = f.ClampPistonFailure
                              ,RestartIssue = f.RestartIssue
                              ,RestartAirLeak =f.RestartAirLeak
                              ,CutterAirLeak = f.CutterAirLeak
                              ,TowJam = f.TowJam
                              ,Papissue = f.Papissue
                              ,ProbeIssue = f.ProbeIssue
                              ,HeadTailstock = f.HeadTailstock
                              ,MaintTroubleshooting = f.MaintTroubleshooting
                              ,CutterReplacement = f.CutterReplacement
                              ,RollerChangeout = f.RollerChangeout
                              ,Miscuts = f.Miscuts
                              ,RestartFailure = f.RestartFailure
                              ,Fod = f.Fod
                              ,MachineDate = f.MachineDate
                              ,Network = g.Network
                              ,Server = g.Server
                              ,ITOther = g.Other
                              ,Itdate = g.Itdate

                          }).ToList();

            return result.AsEnumerable();
        }

        // Get an Equipment Failure
        public VMUnPlannedAvailabilityEquipmentFailure FindEquipmentFailure(int id)
        {
            var result = (from a in _context.Oee
                          join b in _context.UnPlanned on a.Oeeid equals b.Oeeid
                          join c in _context.Availability on b.UnPlannedId equals c.UnPlannedId
                          join d in _context.EquipmentFailure on c.AvailabilityId equals d.AvailabilityId
                          join e in _context.CartMhe on d.EquipmentFailureId equals e.EquipmentFailureId
                          join f in _context.Machine on e.EquipmentFailureId equals f.EquipmentFailureId
                          join g in _context.It on f.EquipmentFailureId equals g.EquipmentFailureId
                          where a.Oeeid == id
                          select new VMUnPlannedAvailabilityEquipmentFailure
                          {
                              Oeeid = a.Oeeid
                              ,
                              UnPlannedId = b.UnPlannedId
                              ,
                              AvailabilityId = c.AvailabilityId
                              ,
                              EquipmentFailureId = d.EquipmentFailureId
                              ,
                              CartMheid = e.CartMheid
                              ,
                              MachineId = f.MachineId
                              ,
                              Itid = g.Itid
                              ,
                              DeadBattery = e.DeadBattery
                              ,
                              BrokenWheels = e.BrokenWheels
                              ,
                              TurntableMalfunction = e.TurntableMalfunction
                              ,
                              CartMHEOther = e.Other
                              ,
                              Oltissue = f.Oltissue
                              ,
                              CutterIssue = f.CutterIssue
                              ,
                              BrokenBulb = f.BrokenBulb
                              ,
                              BrokenSplice = f.BrokenSplice
                              ,
                              Electrical = f.Electrical
                              ,
                              FaultStop = f.FaultStop
                              ,
                              IrheaterError = f.IrheaterError
                              ,
                              FiberDelivery = f.FiberDelivery
                              ,
                              CutterBlade = f.CutterBlade
                              ,
                              ServoFailure = f.ServoFailure
                              ,
                              Tensioner = f.Tensioner
                              ,
                              AxisFailure = f.AxisFailure
                              ,
                              ClampIssue = f.ClampIssue
                              ,
                              ClampPistonFailure = f.ClampPistonFailure
                              ,
                              RestartIssue = f.RestartIssue
                              ,
                              RestartAirLeak = f.RestartAirLeak
                              ,
                              CutterAirLeak = f.CutterAirLeak
                              ,
                              TowJam = f.TowJam
                              ,
                              Papissue = f.Papissue
                              ,
                              ProbeIssue = f.ProbeIssue
                              ,
                              HeadTailstock = f.HeadTailstock
                              ,
                              MaintTroubleshooting = f.MaintTroubleshooting
                              ,
                              CutterReplacement = f.CutterReplacement
                              ,
                              RollerChangeout = f.RollerChangeout
                              ,
                              Miscuts = f.Miscuts
                              ,
                              RestartFailure = f.RestartFailure
                              ,
                              Fod = f.Fod
                              ,
                              MachineDate = f.MachineDate
                              ,
                              Network = g.Network
                              ,
                              Server = g.Server
                              ,
                              ITOther = g.Other
                              ,
                              Itdate = g.Itdate

                          }).SingleOrDefault();

            return result;
        }

        // Get All IdlingMinorStoppage
        IEnumerable<VMUnPlannedPerformanceEfficencyIdlingMinorStoppage> IDashboardRepository.GetAllIdlingMinorStoppage()
        {
            var result = (from a in _context.Oee
                          join b in _context.UnPlanned on a.Oeeid equals b.Oeeid
                          join c in _context.PerformanceEfficiency on b.UnPlannedId equals c.UnPlannedId
                          join d in _context.IdlingMinorStoppage on c.PerformanceEfficiencyId equals d.PerformanceEfficiencyId
                          join e in _context.Constraints on d.IdlingMinorStoppageId equals e.IdlingMinorStoppageId
                          join f in _context.MinorStop on e.IdlingMinorStoppageId equals f.IdlingMinorStoppageId
                          join g in _context.PersonalUnplanned on f.IdlingMinorStoppageId equals g.IdlingMinorStoppageId
                          join h in _context.Ncprogramming on g.IdlingMinorStoppageId equals h.IdlingMinorStoppageId
                          join i in _context.Material on h.IdlingMinorStoppageId equals i.IdlingMinorStoppageId

                          select new VMUnPlannedPerformanceEfficencyIdlingMinorStoppage
                          {
                              Oeeid = a.Oeeid
                              ,UnPlannedId = b.UnPlannedId
                              ,PerformanceEfficiencyId = c.PerformanceEfficiencyId
                              ,IdlingMinorStoppageId = d.IdlingMinorStoppageId
                              ,ConstraintsId = e.ConstraintsId
                              ,MinorStopId = f.MinorStopId
                              ,PersonalUnplannedId = g.PersonalUnplannedId
                              ,NcprogrammingId = h.NcprogrammingId
                              ,MaterialId = i.MaterialId
                              ,NoBarrel = e.NoBarrel
                              ,NoOperator = e.NoOperator
                              ,WaitingForInspection = e.WaitingForInspection
                              ,ConstraintsOther = e.Other
                              ,ConstraintsDate = e.ConstraintsDate
                              ,_25minute = f._25minute
                              ,MinorStopDate = f.MinorStopDate
                              ,MeetingUnplanned = g.MeetingUnplanned
                              ,OperatorRelief = g.OperatorRelief
                              ,PersonalUnplannedDate = g.PersonalUnplannedDate
                              ,NcprogramIssue = h.NcprogramIssue
                              ,NcprogrammingOther = h.Other
                              ,PolyWrap = i.PolyWrap
                              ,NotStickingIml = i.NotStickingIml
                              ,CompactionRollerIssue = i.CompactionRollerIssue
                              ,CrossedTow = i.CrossedTow
                              ,SpliceBreak = i.SpliceBreak
                              ,TowJumpOffRoller = i.TowJumpOffRoller
                              ,LostTow = i.LostTow
                              ,TowShredding = i.TowShredding
                              ,CleanOutFod = i.CleanOutFod
                              ,TowWrapOnqRoller = i.TowWrapOnqRoller
                              ,MaterialDate = i.MaterialDate

                          }).ToList();

            return result.AsEnumerable();
        }

        // Get an IdlingMinorStoppage
        public VMUnPlannedPerformanceEfficencyIdlingMinorStoppage FindIdlingMinorStoppage(int id)
        {
            var result = (from a in _context.Oee
                          join b in _context.UnPlanned on a.Oeeid equals b.Oeeid
                          join c in _context.PerformanceEfficiency on b.UnPlannedId equals c.UnPlannedId
                          join d in _context.IdlingMinorStoppage on c.PerformanceEfficiencyId equals d.PerformanceEfficiencyId
                          join e in _context.Constraints on d.IdlingMinorStoppageId equals e.IdlingMinorStoppageId
                          join f in _context.MinorStop on e.IdlingMinorStoppageId equals f.IdlingMinorStoppageId
                          join g in _context.PersonalUnplanned on f.IdlingMinorStoppageId equals g.IdlingMinorStoppageId
                          join h in _context.Ncprogramming on g.IdlingMinorStoppageId equals h.IdlingMinorStoppageId
                          join i in _context.Material on h.IdlingMinorStoppageId equals i.IdlingMinorStoppageId
                          where a.Oeeid == id
                          select new VMUnPlannedPerformanceEfficencyIdlingMinorStoppage
                          {
                              Oeeid = a.Oeeid
                              ,
                              UnPlannedId = b.UnPlannedId
                              ,
                              PerformanceEfficiencyId = c.PerformanceEfficiencyId
                              ,
                              IdlingMinorStoppageId = d.IdlingMinorStoppageId
                              ,
                              ConstraintsId = e.ConstraintsId
                              ,
                              MinorStopId = f.MinorStopId
                              ,
                              PersonalUnplannedId = g.PersonalUnplannedId
                              ,
                              NcprogrammingId = h.NcprogrammingId
                              ,
                              MaterialId = i.MaterialId
                              ,
                              NoBarrel = e.NoBarrel
                              ,
                              NoOperator = e.NoOperator
                              ,
                              WaitingForInspection = e.WaitingForInspection
                              ,
                              ConstraintsOther = e.Other
                              ,
                              ConstraintsDate = e.ConstraintsDate
                              ,
                              _25minute = f._25minute
                              ,
                              MinorStopDate = f.MinorStopDate
                              ,
                              MeetingUnplanned = g.MeetingUnplanned
                              ,
                              OperatorRelief = g.OperatorRelief
                              ,
                              PersonalUnplannedDate = g.PersonalUnplannedDate
                              ,
                              NcprogramIssue = h.NcprogramIssue
                              ,
                              NcprogrammingOther = h.Other
                              ,
                              PolyWrap = i.PolyWrap
                              ,
                              NotStickingIml = i.NotStickingIml
                              ,
                              CompactionRollerIssue = i.CompactionRollerIssue
                              ,
                              CrossedTow = i.CrossedTow
                              ,
                              SpliceBreak = i.SpliceBreak
                              ,
                              TowJumpOffRoller = i.TowJumpOffRoller
                              ,
                              LostTow = i.LostTow
                              ,
                              TowShredding = i.TowShredding
                              ,
                              CleanOutFod = i.CleanOutFod
                              ,
                              TowWrapOnqRoller = i.TowWrapOnqRoller
                              ,
                              MaterialDate = i.MaterialDate

                          }).SingleOrDefault();

            return result;
        }

        // Get All SetupAdjustment
        IEnumerable<VMUnPlannedAvailabilitySetupAdjustment> IDashboardRepository.GetAllSetupAdjustment()
        {
            var result = (from a in _context.Oee
                          join b in _context.UnPlanned on a.Oeeid equals b.Oeeid
                          join c in _context.Availability on b.UnPlannedId equals c.UnPlannedId
                          join d in _context.SetupAdjustment on c.AvailabilityId equals d.AvailabilityId
                          join e in _context.LoadUnload on d.SetupAdjustmentId equals e.SetupAdjustmentId
                          join f in _context.CalibrationAlignment on e.SetupAdjustmentId equals f.SetupAdjustmentId

                          select new VMUnPlannedAvailabilitySetupAdjustment
                          {
                              Oeeid = a.Oeeid
                              ,UnPlannedId = b.UnPlannedId
                              ,AvailabilityId = c.AvailabilityId
                              ,SetupAdjustmentId = d.SetupAdjustmentId
                              ,LoadUnloadId = e.LoadUnloadId
                              ,CalibrationAlignmentId = f.CalibrationAlignmentId
                              ,Load = e.Load
                              ,Unload = e.Unload
                              ,Debag = e.Debag
                              ,InterimClean = e.InterimClean
                              ,PreClean = e.PreClean
                              ,PostClean = e.PostClean
                              ,AwaitingProgram = e.AwaitingProgram
                              ,LoadUnloadDate = e.LoadUnloadDate
                              ,Probe = f.Probe
                              ,SpoolChanges = f.SpoolChanges
                              ,InspectIml = f.InspectIml
                              ,CalibrationDate = f.CalibrationDate

                          }).ToList();

            return result.AsEnumerable();
        }

        // Get an SetupAdjustment
        public VMUnPlannedAvailabilitySetupAdjustment FindSetupAdjustment(int id)
        {
            var result = (from a in _context.Oee
                          join b in _context.UnPlanned on a.Oeeid equals b.Oeeid
                          join c in _context.Availability on b.UnPlannedId equals c.UnPlannedId
                          join d in _context.SetupAdjustment on c.AvailabilityId equals d.AvailabilityId
                          join e in _context.LoadUnload on d.SetupAdjustmentId equals e.SetupAdjustmentId
                          join f in _context.CalibrationAlignment on e.SetupAdjustmentId equals f.SetupAdjustmentId
                          where a.Oeeid == id
                          select new VMUnPlannedAvailabilitySetupAdjustment
                          {
                              Oeeid = a.Oeeid
                              ,
                              UnPlannedId = b.UnPlannedId
                              ,
                              AvailabilityId = c.AvailabilityId
                              ,
                              SetupAdjustmentId = d.SetupAdjustmentId
                              ,
                              LoadUnloadId = e.LoadUnloadId
                              ,
                              CalibrationAlignmentId = f.CalibrationAlignmentId
                              ,
                              Load = e.Load
                              ,
                              Unload = e.Unload
                              ,
                              Debag = e.Debag
                              ,
                              InterimClean = e.InterimClean
                              ,
                              PreClean = e.PreClean
                              ,
                              PostClean = e.PostClean
                              ,
                              AwaitingProgram = e.AwaitingProgram
                              ,
                              LoadUnloadDate = e.LoadUnloadDate
                              ,
                              Probe = f.Probe
                              ,
                              SpoolChanges = f.SpoolChanges
                              ,
                              InspectIml = f.InspectIml
                              ,
                              CalibrationDate = f.CalibrationDate

                          }).SingleOrDefault();

            return result;
        }

        // Get All ReducedSpeed
        IEnumerable<VMUnPlannedPerformanceEfficencyIdlingReducedSpeed> IDashboardRepository.GetAllReducedSpeed()
        {
            var result = (from a in _context.Oee
                          join b in _context.UnPlanned on a.Oeeid equals b.Oeeid
                          join c in _context.PerformanceEfficiency on b.UnPlannedId equals c.UnPlannedId
                          join d in _context.ReducedSpeed on c.PerformanceEfficiencyId equals d.PerformanceEfficiencyId
                          select new VMUnPlannedPerformanceEfficencyIdlingReducedSpeed
                          {
                              Oeeid = a.Oeeid
                              ,UnPlannedId = b.UnPlannedId
                              ,PerformanceEfficiencyId = c.PerformanceEfficiencyId
                              ,ReducedSpeedId = d.ReducedSpeedId
                              ,ReduceFeedrate = d.ReduceFeedrate
                              ,ReduceSpeedDate = d.ReduceSpeedDate

                          }).ToList();

            return result.AsEnumerable();
        }

        // Get an ReducedSpeed
        public VMUnPlannedPerformanceEfficencyIdlingReducedSpeed FindReducedSpeed(int id)
        {
            var result = (from a in _context.Oee
                          join b in _context.UnPlanned on a.Oeeid equals b.Oeeid
                          join c in _context.PerformanceEfficiency on b.UnPlannedId equals c.UnPlannedId
                          join d in _context.ReducedSpeed on c.PerformanceEfficiencyId equals d.PerformanceEfficiencyId
                          where a.Oeeid == id
                          select new VMUnPlannedPerformanceEfficencyIdlingReducedSpeed
                          {
                              Oeeid = a.Oeeid
                              ,
                              UnPlannedId = b.UnPlannedId
                              ,
                              PerformanceEfficiencyId = c.PerformanceEfficiencyId
                              ,
                              ReducedSpeedId = d.ReducedSpeedId
                              ,
                              ReduceFeedrate = d.ReduceFeedrate
                              ,
                              ReduceSpeedDate = d.ReduceSpeedDate

                          }).SingleOrDefault();

            return result;
        }
    }
}
