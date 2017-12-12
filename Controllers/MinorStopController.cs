using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class MinorStopController : Controller
    {
        // Constructor
        public MinorStopController(IMinorStopRepository repository)
        {
            repo = repository;
        }
        public IMinorStopRepository repo { get; set; }

        // GET: api/v1/minorstop
        [HttpGet]
        public IEnumerable<MinorStop> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/minorstop{id}
        [HttpGet("{id}", Name = "GetMinorStop")]
        public IActionResult GetById(int id)
        {
            var minorstop = repo.Find(id);
            if (minorstop == null)
            {
                return NotFound();
            }
            return new ObjectResult(minorstop);
        }

        // POST: api/v1/minorstop
        [HttpPost]
        public IActionResult Create([FromBody] MinorStop minorstop)
        {
            if (minorstop == null)
            {
                return BadRequest();
            }
            repo.Add(minorstop);
            return CreatedAtRoute("GetMinorStop", new { id = minorstop.MinorStopId }, minorstop);
        }

        // PUT: api/v1/minorstop/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MinorStop minorstop)
        {
            if (minorstop == null || minorstop.MinorStopId != id)
            {
                return BadRequest();
            }

            var minorstopItem = repo.Find(id);
            if (minorstopItem == null)
            {
                return NotFound();
            }

            repo.Update(minorstop);
            return new NoContentResult();
        }

        // DELETE api/v1/minorstop/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var minorstopItem = repo.Find(id);
            if (minorstopItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
