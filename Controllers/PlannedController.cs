using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class PlannedController : Controller
    {
        // Constructor
        public PlannedController(IPlannedRepository repository)
        {
            repo = repository;
        }
        public IPlannedRepository repo { get; set; }

        // GET: api/v1/planned
        [HttpGet]
        public IEnumerable<Planned> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/planned{id}
        [HttpGet("{id}", Name = "GetPlanned")]
        public IActionResult GetById(int id)
        {
            var planned = repo.Find(id);
            if (planned == null)
            {
                return NotFound();
            }
            return new ObjectResult(planned);
        }

        // POST: api/v1/planned
        [HttpPost]
        public IActionResult Create([FromBody] Planned planned)
        {
            if (planned == null)
            {
                return BadRequest();
            }
            repo.Add(planned);
            return CreatedAtRoute("GetPlanned", new { id = planned.PlannedId }, planned);
        }

        // PUT: api/v1/planned/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Planned planned)
        {
            if (planned == null || planned.PlannedId != id)
            {
                return BadRequest();
            }

            var plannedItem = repo.Find(id);
            if (plannedItem == null)
            {
                return NotFound();
            }

            repo.Update(planned);
            return new NoContentResult();
        }

        // DELETE api/v1/planned/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var plannedItem = repo.Find(id);
            if (plannedItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
