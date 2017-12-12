using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class NCProgrammingController : Controller
    {
        // Constructor
        public NCProgrammingController(INCProgrammingRepository repository)
        {
            repo = repository;
        }
        public INCProgrammingRepository repo { get; set; }

        // GET: api/v1/ncprogamming
        [HttpGet]
        public IEnumerable<Ncprogramming> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/ncprogamming{id}
        [HttpGet("{id}", Name = "GetNCProgramming")]
        public IActionResult GetById(int id)
        {
            var ncprogamming = repo.Find(id);
            if (ncprogamming == null)
            {
                return NotFound();
            }
            return new ObjectResult(ncprogamming);
        }

        // POST: api/v1/ncprogramming
        [HttpPost]
        public IActionResult Create([FromBody] Ncprogramming ncprogramming)
        {
            if (ncprogramming == null)
            {
                return BadRequest();
            }
            repo.Add(ncprogramming);
            return CreatedAtRoute("GetNCProgramming", new { id = ncprogramming.NcprogrammingId }, ncprogramming);
        }

        // PUT: api/v1/ncprogramming/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Ncprogramming ncprogramming)
        {
            if (ncprogramming == null || ncprogramming.NcprogrammingId != id)
            {
                return BadRequest();
            }

            var ncprogrammingItem = repo.Find(id);
            if (ncprogrammingItem == null)
            {
                return NotFound();
            }

            repo.Update(ncprogramming);
            return new NoContentResult();
        }

        // DELETE api/v1/ncprogamming/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ncprogammingItem = repo.Find(id);
            if (ncprogammingItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
