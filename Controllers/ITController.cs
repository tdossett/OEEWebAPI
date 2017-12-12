using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class ITController : Controller
    {
        // Constructor
        public ITController(IITRepository repository)
        {
            repo = repository;
        }
        public IITRepository repo { get; set; }

        // GET: api/v1/it
        [HttpGet]
        public IEnumerable<It> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/it{id}
        [HttpGet("{id}", Name = "GetIt")]
        public IActionResult GetById(int id)
        {
            var it = repo.Find(id);
            if (it == null)
            {
                return NotFound();
            }
            return new ObjectResult(it);
        }

        // POST: api/v1/it
        [HttpPost]
        public IActionResult Create([FromBody] It it)
        {
            if (it == null)
            {
                return BadRequest();
            }
            repo.Add(it);
            return CreatedAtRoute("GetIt", new { id = it.Itid }, it);
        }

        // PUT: api/v1/it/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] It it)
        {
            if (it == null || it.Itid != id)
            {
                return BadRequest();
            }

            var itItem = repo.Find(id);
            if (itItem == null)
            {
                return NotFound();
            }

            repo.Update(it);
            return new NoContentResult();
        }

        // DELETE api/v1/it/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var itItem = repo.Find(id);
            if (itItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }

    }
}
