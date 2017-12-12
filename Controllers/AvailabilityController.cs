using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class AvailabilityController : Controller
    {
        // Constructor
        public AvailabilityController(IAvailabilityRepository repository)
        {
            repo = repository;
        }
        public IAvailabilityRepository repo { get; set; }

        // GET: api/v1/availability
        [HttpGet]
        public IEnumerable<Availability> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/availability{id}
        [HttpGet("{id}", Name = "GetAvailabilty")]
        public IActionResult GetById(int id)
        {
            var availabilty = repo.Find(id);
            if (availabilty == null)
            {
                return NotFound();
            }
            return new ObjectResult(availabilty);
        }

        // POST: api/v1/availability
        [HttpPost]
        public IActionResult Create([FromBody] Availability availability)
        {
            if (availability == null)
            {
                return BadRequest();
            }
            repo.Add(availability);
            return CreatedAtRoute("GetAvailability", new { id = availability.AvailabilityId }, availability);
        }

        // PUT: api/v1/availability/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Availability availability)
        {
            if (availability == null || availability.AvailabilityId != id)
            {
                return BadRequest();
            }

            var availabilityItem = repo.Find(id);
            if (availabilityItem == null)
            {
                return NotFound();
            }

            repo.Update(availability);
            return new NoContentResult();
        }

        // DELETE api/v1/availability/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var availabilityItem = repo.Find(id);
            if (availabilityItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }

    }
}
