using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class LoadUnloadController : Controller
    {
        // Constructor
        public LoadUnloadController(ILoadUnloadRepository repository)
        {
            repo = repository;
        }
        public ILoadUnloadRepository repo { get; set; }

        // GET: api/v1/loadunload
        [HttpGet]
        public IEnumerable<LoadUnload> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/loadunload{id}
        [HttpGet("{id}", Name = "GetLoadUnload")]
        public IActionResult GetById(int id)
        {
            var loadunload = repo.Find(id);
            if (loadunload == null)
            {
                return NotFound();
            }
            return new ObjectResult(loadunload);
        }

        // POST: api/v1/loadunload
        [HttpPost]
        public IActionResult Create([FromBody] LoadUnload loadunload)
        {
            if (loadunload == null)
            {
                return BadRequest();
            }
            repo.Add(loadunload);
            return CreatedAtRoute("GetLoadUnload", new { id = loadunload.LoadUnloadId }, loadunload);
        }

        // PUT: api/v1/loadunload/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] LoadUnload loadunload)
        {
            if (loadunload == null || loadunload.LoadUnloadId != id)
            {
                return BadRequest();
            }

            var loadunloadItem = repo.Find(id);
            if (loadunloadItem == null)
            {
                return NotFound();
            }

            repo.Update(loadunload);
            return new NoContentResult();
        }

        // DELETE api/v1/oee/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var loadunloadItem = repo.Find(id);
            if (loadunloadItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
