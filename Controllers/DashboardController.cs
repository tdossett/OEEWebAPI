using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.ViewModels;
using OEEWebAPI.Interfaces;

namespace OEEWebAPI.Controllers
{
    public class DashboardController : Controller
    {
        public DashboardController(IDashboardRepository repository)
        {
            repo = repository;
        }
        public IDashboardRepository repo { get; set; }

        // GET: api/v1/Dashboard/Planned
        [HttpGet("api/v1/[controller]/Planned")]
        public IEnumerable<VMPlanned> GetAllPlanned()
        {
            return repo.GetAllPlanned();
        }

        // GET: api/v1/Dashboard/Plan/{id}
        [HttpGet("api/v1/[controller]/Plan/{id}", Name = "GetPlan")]
        public IActionResult FindPlan(int id)
        {
            var plan = repo.FindPlan(id);
            if (plan == null)
            {
                return NotFound();
            }
            return new ObjectResult(plan);
        }

        // GET: api/v1/Dashboard/EquipmentFailure
        [HttpGet("api/v1/[controller]/EquipmentFailure")]
        public IEnumerable<VMUnPlannedAvailabilityEquipmentFailure> GetAllEquipmentFailure()
        {
            return repo.GetAllEquipmentFailure();
        }

        // GET: api/v1/Dashboard/EquipmentFailure/{id}
        [HttpGet("api/v1/[controller]/EquipmentFailure/{id}", Name = "GetEqmntFailure")]
        public IActionResult FindEquipmentFailure(int id)
        {
            var equipmentfailure = repo.FindEquipmentFailure(id);
            if (equipmentfailure == null)
            {
                return NotFound();
            }
            return new ObjectResult(equipmentfailure);
        }

        // GET: api/v1/Dashboard/IdlingMinorStoppage
        [HttpGet("api/v1/[controller]/IdlingMinorStoppage")]
        public IEnumerable<VMUnPlannedPerformanceEfficencyIdlingMinorStoppage> GetAllIdlingMinorStoppage()
        {
            return repo.GetAllIdlingMinorStoppage();
        }

        // GET: api/v1/Dashboard/IdlingMinorStoppage/{id}
        [HttpGet("api/v1/[controller]/IdlingMinorStoppage/{id}", Name = "GetIdlingMS")]
        public IActionResult FindIdlingMinorStoppage(int id)
        {
            var idlingminorstoppage = repo.FindIdlingMinorStoppage(id);
            if (idlingminorstoppage == null)
            {
                return NotFound();
            }
            return new ObjectResult(idlingminorstoppage);
        }

        // GET: api/v1/Dashboard/SetupAdjustment
        [HttpGet("api/v1/[controller]/SetupAdjustment")]
        public IEnumerable<VMUnPlannedAvailabilitySetupAdjustment> GetAllSetupAdjustment()
        {
            return repo.GetAllSetupAdjustment();
        }

        // GET: api/v1/Dashboard/SetupAdjustment/{id}
        [HttpGet("api/v1/[controller]/SetupAdjustment/{id}", Name = "GetSetupAdjmnt")]
        public IActionResult FindSetupAdjustment(int id)
        {
            var setupadjustment = repo.FindSetupAdjustment(id);
            if (setupadjustment == null)
            {
                return NotFound();
            }
            return new ObjectResult(setupadjustment);
        }

        // GET: api/v1/Dashboard/ReducedSpeed
        [HttpGet("api/v1/[controller]/ReducedSpeed")]
        public IEnumerable<VMUnPlannedPerformanceEfficencyIdlingReducedSpeed> GetAllReducedSpeed()
        {
            return repo.GetAllReducedSpeed();
        }

        // GET: api/v1/Dashboard/ReducedSpeed/{id}
        [HttpGet("api/v1/[controller]/ReducedSpeed/{id}", Name = "GetRedSpeed")]
        public IActionResult FindReducedSpeed(int id)
        {
            var reducedspeed = repo.FindReducedSpeed(id);
            if (reducedspeed == null)
            {
                return NotFound();
            }
            return new ObjectResult(reducedspeed);
        }


    }
}
