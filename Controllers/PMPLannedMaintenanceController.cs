using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class PMPLannedMaintenanceController : Controller
    {
        // Constructor
        public PMPLannedMaintenanceController(IPMPlannedMaintenanceRepository repository)
        {
            repo = repository;
        }
        public IPMPlannedMaintenanceRepository repo { get; set; }

        // GET: api/v1/pmplannedmaintenance
        [HttpGet]
        public IEnumerable<PmplannedMaintenance> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/pmplannedmaintenance{id}
        [HttpGet("{id}", Name = "GetPMPlannedMaintenance")]
        public IActionResult GetById(int id)
        {
            var pmplannedmaintenance = repo.Find(id);
            if (pmplannedmaintenance == null)
            {
                return NotFound();
            }
            return new ObjectResult(pmplannedmaintenance);
        }

        // POST: api/v1/pmplannedmaintenance
        [HttpPost]
        public IActionResult Create([FromBody] PmplannedMaintenance pmplannedmaintenance)
        {
            if (pmplannedmaintenance == null)
            {
                return BadRequest();
            }
            repo.Add(pmplannedmaintenance);
            return CreatedAtRoute("GetPMPLannedMaintenance", new { id = pmplannedmaintenance.PmplannedMaintenanceId }, pmplannedmaintenance);
        }

        // PUT: api/v1/pmplannedmaintenance/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PmplannedMaintenance pmplannedmaintenance)
        {
            if (pmplannedmaintenance == null || pmplannedmaintenance.PmplannedMaintenanceId != id)
            {
                return BadRequest();
            }

            var pmplannedmaintenanceItem = repo.Find(id);
            if (pmplannedmaintenanceItem == null)
            {
                return NotFound();
            }

            repo.Update(pmplannedmaintenance);
            return new NoContentResult();
        }

        // DELETE api/v1/pmplannedmaintenance/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pmplannedmaintenanceItem = repo.Find(id);
            if (pmplannedmaintenanceItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
