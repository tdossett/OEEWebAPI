using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class OEEController : Controller
    {
        // Constructor
        public OEEController(IOEERepository repository)
        {
            repo = repository;
        }
        public IOEERepository repo { get; set; }

        // GET: api/v1/oee
        [HttpGet]
        public IEnumerable<Oee> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/oee{id}
        [HttpGet("{id}", Name ="GetOee")]
        public IActionResult GetById(int id)
        {
            var oee = repo.Find(id);
            if (oee == null)
            {
                return NotFound();
            }
            return new ObjectResult(oee);
        }

        // POST: api/v1/oee
        [HttpPost]
        public IActionResult Create([FromBody] Oee oee)
        {
            if (oee == null)
            {
                return BadRequest();
            }
            repo.Add(oee);
            return CreatedAtRoute("GetOee", new { id = oee.Oeeid }, oee);
        }

        // PUT: api/v1/oee/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Oee oee)
        {
            if (oee == null || oee.Oeeid != id)
            {
                return BadRequest();
            }

            var oeeItem = repo.Find(id);
            if (oeeItem == null)
            {
                return NotFound();
            }

            repo.Update(oee);
            return new NoContentResult();
        }

        // DELETE api/v1/oee/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var oeeItem = repo.Find(id);
            if (oeeItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
