using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class ConstraintsController : Controller
    {
        // Constructor
        public ConstraintsController(IConstraintsRepository repository)
        {
            repo = repository;
        }
        public IConstraintsRepository repo { get; set; }

        // GET: api/v1/constraints
        [HttpGet]
        public IEnumerable<Constraints> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/constraint{id}
        [HttpGet("{id}", Name = "GetConstraint")]
        public IActionResult GetById(int id)
        {
            var constraint = repo.Find(id);
            if (constraint == null)
            {
                return NotFound();
            }
            return new ObjectResult(constraint);
        }

        // POST: api/v1/constraint
        [HttpPost]
        public IActionResult Create([FromBody] Constraints constraint)
        {
            if (constraint == null)
            {
                return BadRequest();
            }
            repo.Add(constraint);
            return CreatedAtRoute("GetConstraint", new { id = constraint.ConstraintsId }, constraint);
        }

        // PUT: api/v1/constraint/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Constraints constraint)
        {
            if (constraint == null || constraint.ConstraintsId != id)
            {
                return BadRequest();
            }

            var constraintItem = repo.Find(id);
            if (constraintItem == null)
            {
                return NotFound();
            }

            repo.Update(constraint);
            return new NoContentResult();
        }

        // DELETE api/v1/constraint/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var constraintItem = repo.Find(id);
            if (constraintItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
