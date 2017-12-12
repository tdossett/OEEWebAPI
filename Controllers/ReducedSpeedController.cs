using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class ReducedSpeedController : Controller
    {
        // Constructor
        public ReducedSpeedController(IReducedSpeedRespository repository)
        {
            repo = repository;
        }
        public IReducedSpeedRespository repo { get; set; }

        // GET: api/v1/reducedspeed
        [HttpGet]
        public IEnumerable<ReducedSpeed> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/reducedspeed{id}
        [HttpGet("{id}", Name = "GetReducedSpeed")]
        public IActionResult GetById(int id)
        {
            var reducedspeed = repo.Find(id);
            if (reducedspeed == null)
            {
                return NotFound();
            }
            return new ObjectResult(reducedspeed);
        }

        // POST: api/v1/reducedspeed
        [HttpPost]
        public IActionResult Create([FromBody] ReducedSpeed reducedspeed)
        {
            if (reducedspeed == null)
            {
                return BadRequest();
            }
            repo.Add(reducedspeed);
            return CreatedAtRoute("GetReducedSpeed", new { id = reducedspeed.ReducedSpeedId }, reducedspeed);
        }

        // PUT: api/v1/reducedspeed/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ReducedSpeed reducedspeed)
        {
            if (reducedspeed == null || reducedspeed.ReducedSpeedId != id)
            {
                return BadRequest();
            }

            var reducedspeedItem = repo.Find(id);
            if (reducedspeedItem == null)
            {
                return NotFound();
            }

            repo.Update(reducedspeed);
            return new NoContentResult();
        }

        // DELETE api/v1/reducedspeed/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var reducedspeedItem = repo.Find(id);
            if (reducedspeedItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
