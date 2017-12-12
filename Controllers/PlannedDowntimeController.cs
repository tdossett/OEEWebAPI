using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class PlannedDowntimeController : Controller
    {
        // Constructor
        public PlannedDowntimeController(IPlannedDowntimeRepository repository)
        {
            repo = repository;
        }
        public IPlannedDowntimeRepository repo { get; set; }

        // GET: api/v1/planneddowntime
        [HttpGet]
        public IEnumerable<PlannedDowntime> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/planneddowntime{id}
        [HttpGet("{id}", Name = "GetPlannedDowntime")]
        public IActionResult GetById(int id)
        {
            var planneddowntime = repo.Find(id);
            if (planneddowntime == null)
            {
                return NotFound();
            }
            return new ObjectResult(planneddowntime);
        }

        // POST: api/v1/planneddowntime
        [HttpPost]
        public IActionResult Create([FromBody] PlannedDowntime planneddowntime)
        {
            if (planneddowntime == null)
            {
                return BadRequest();
            }
            repo.Add(planneddowntime);
            return CreatedAtRoute("GetPlannedDowntime", new { id = planneddowntime.PlannedDowntimeId }, planneddowntime);
        }

        // PUT: api/v1/planneddowntime/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PlannedDowntime planneddowntime)
        {
            if (planneddowntime == null || planneddowntime.PlannedDowntimeId != id)
            {
                return BadRequest();
            }

            var planneddowntimeItem = repo.Find(id);
            if (planneddowntimeItem == null)
            {
                return NotFound();
            }

            repo.Update(planneddowntime);
            return new NoContentResult();
        }

        // DELETE api/v1/planneddowntime/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var planneddowntimeItem = repo.Find(id);
            if (planneddowntimeItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
