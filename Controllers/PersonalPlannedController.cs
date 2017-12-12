using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class PersonalPlannedController : Controller
    {
        // Constructor
        public PersonalPlannedController(IPersonalPlannedRepository repository)
        {
            repo = repository;
        }
        public IPersonalPlannedRepository repo { get; set; }

        // GET: api/v1/personalplanned
        [HttpGet]
        public IEnumerable<PersonalPanned> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/personalplanned{id}
        [HttpGet("{id}", Name = "GetPersonalPlanned")]
        public IActionResult GetById(int id)
        {
            var personalplanned = repo.Find(id);
            if (personalplanned == null)
            {
                return NotFound();
            }
            return new ObjectResult(personalplanned);
        }

        // POST: api/v1/personalplanned
        [HttpPost]
        public IActionResult Create([FromBody] PersonalPanned personalplanned)
        {
            if (personalplanned == null)
            {
                return BadRequest();
            }
            repo.Add(personalplanned);
            return CreatedAtRoute("GetPersonalPlanned", new { id = personalplanned.PersonalPannedId }, personalplanned);
        }

        // PUT: api/v1/personalplanned/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PersonalPanned personalplanned)
        {
            if (personalplanned == null || personalplanned.PersonalPannedId != id)
            {
                return BadRequest();
            }

            var personalplannedItem = repo.Find(id);
            if (personalplannedItem == null)
            {
                return NotFound();
            }

            repo.Update(personalplanned);
            return new NoContentResult();
        }

        // DELETE api/v1/personalplanned/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var personalplannedItem = repo.Find(id);
            if (personalplannedItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
