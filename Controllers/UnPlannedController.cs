using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class UnPlannedController : Controller
    {
        // Constructor
        public UnPlannedController(IUnPlannedRepository repository)
        {
            repo = repository;
        }
        public IUnPlannedRepository repo { get; set; }

        // GET: api/v1/unplanned
        [HttpGet]
        public IEnumerable<UnPlanned> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/unplanned{id}
        [HttpGet("{id}", Name = "GetUnPlanned")]
        public IActionResult GetById(int id)
        {
            var unplanned = repo.Find(id);
            if (unplanned == null)
            {
                return NotFound();
            }
            return new ObjectResult(unplanned);
        }

        // POST: api/v1/unplanned
        [HttpPost]
        public IActionResult Create([FromBody] UnPlanned unplanned)
        {
            if (unplanned == null)
            {
                return BadRequest();
            }
            repo.Add(unplanned);
            return CreatedAtRoute("GetUnPlanned", new { id = unplanned.UnPlannedId }, unplanned);
        }

        // PUT: api/v1/unplanned/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UnPlanned unplanned)
        {
            if (unplanned == null || unplanned.UnPlannedId != id)
            {
                return BadRequest();
            }

            var unplannedItem = repo.Find(id);
            if (unplannedItem == null)
            {
                return NotFound();
            }

            repo.Update(unplanned);
            return new NoContentResult();
        }

        // DELETE api/v1/unplanned/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var unplannedItem = repo.Find(id);
            if (unplannedItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
