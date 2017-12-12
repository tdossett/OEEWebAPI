using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class MachineRepository : IMachineRepository
    {
        private OEEContext _context;

        // Constructor
        public MachineRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All Machine's
        IEnumerable<Machine> IMachineRepository.GetAll()
        {
            var machine = _context.Machine;

            return machine.AsEnumerable();
        }

        // Get an Machine
        public Machine Find(int id)
        {
            var machine = _context.Machine.Single(o => o.MachineId == id);

            return machine;
        }

        // Add an Machine
        public void Add(Machine machine)
        {
            _context.Machine.Add(machine);
            _context.SaveChanges();
        }

        // Update an Machine
        public void Update(Machine machine)
        {
            var machineToUpdate = _context.Machine.Single(o => o.MachineId == machine.MachineId);
            if (machineToUpdate != null)
            {
                machineToUpdate.Oltissue = machine.Oltissue;
                machineToUpdate.BrokenBulb = machine.BrokenBulb;
                machineToUpdate.BrokenSplice = machine.BrokenSplice;
                machineToUpdate.Electrical = machine.Electrical;
                machineToUpdate.FaultStop = machine.FaultStop;
                machineToUpdate.IrheaterError = machine.IrheaterError;
                machineToUpdate.FiberDelivery = machine.FiberDelivery;
                machineToUpdate.CutterBlade = machine.CutterBlade;
                machineToUpdate.ServoFailure = machine.ServoFailure;
                machineToUpdate.Tensioner = machine.Tensioner;
                machineToUpdate.AxisFailure = machine.AxisFailure;
                machineToUpdate.ClampIssue = machine.ClampIssue;
                machineToUpdate.ClampAirLeak = machine.ClampAirLeak;
                machineToUpdate.ClampPistonFailure = machine.ClampPistonFailure;
                machineToUpdate.RestartIssue = machine.RestartIssue;
                machineToUpdate.RestartAirLeak = machine.RestartAirLeak;
                machineToUpdate.CutterAirLeak = machine.CutterAirLeak;
                machineToUpdate.TowJam = machine.TowJam;
                machineToUpdate.Papissue = machine.Papissue;
                machineToUpdate.ProbeIssue = machine.ProbeIssue;
                machineToUpdate.HeadTailstock = machine.HeadTailstock;
                machineToUpdate.MaintTroubleshooting = machine.MaintTroubleshooting;
                machineToUpdate.CutterReplacement = machine.CutterReplacement;
                machineToUpdate.RollerChangeout = machine.RollerChangeout;
                machineToUpdate.Miscuts = machine.Miscuts;
                machineToUpdate.RestartFailure = machine.RestartFailure;
                machineToUpdate.Fod = machine.Fod;
                machineToUpdate.MachineDate = machine.MachineDate;
                _context.SaveChanges();
            }
        }

        // Remove an Oee
        public void Remove(int id)
        {
            var machineToRemove = _context.Machine.Single(o => o.MachineId == id);
            if (machineToRemove != null)
            {
                _context.Remove(machineToRemove);
                _context.SaveChanges();
            }
        }
    }
}
