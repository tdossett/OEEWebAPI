using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class PersonalUnplannedController : Controller
    {
        // Constructor
        public PersonalUnplannedController(IPersonalUnplannedRepository repository)
        {
            repo = repository;
        }
        public IPersonalUnplannedRepository repo { get; set; }

        // GET: api/v1/personalunplanned
        [HttpGet]
        public IEnumerable<PersonalUnplanned> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/personalunplanned{id}
        [HttpGet("{id}", Name = "GetPersonalUnplanned")]
        public IActionResult GetById(int id)
        {
            var personalunplanned = repo.Find(id);
            if (personalunplanned == null)
            {
                return NotFound();
            }
            return new ObjectResult(personalunplanned);
        }

        // POST: api/v1/personalunplanned
        [HttpPost]
        public IActionResult Create([FromBody] PersonalUnplanned personalunplanned)
        {
            if (personalunplanned == null)
            {
                return BadRequest();
            }
            repo.Add(personalunplanned);
            return CreatedAtRoute("GetpersonalUnplanned", new { id = personalunplanned.PersonalUnplannedId }, personalunplanned);
        }

        // PUT: api/v1/personalunplanned/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PersonalUnplanned personalunplanned)
        {
            if (personalunplanned == null || personalunplanned.PersonalUnplannedId != id)
            {
                return BadRequest();
            }

            var personalunplannedItem = repo.Find(id);
            if (personalunplannedItem == null)
            {
                return NotFound();
            }

            repo.Update(personalunplanned);
            return new NoContentResult();
        }

        // DELETE api/v1/personalunplanned/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var personalunplannedItem = repo.Find(id);
            if (personalunplannedItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
