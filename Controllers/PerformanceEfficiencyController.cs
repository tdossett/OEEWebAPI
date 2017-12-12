using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

namespace OEEWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PerformanceEfficiencyController : Controller
    {
        // Constructor
        public PerformanceEfficiencyController(IPerformanceEfficiencyRepository repository)
        {
            repo = repository;
        }
        public IPerformanceEfficiencyRepository repo { get; set; }

        // GET: api/v1/performanceefficiency
        [HttpGet]
        public IEnumerable<PerformanceEfficiency> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/performanceefficiency{id}
        [HttpGet("{id}", Name = "GetPerformanceEfficiency")]
        public IActionResult GetById(int id)
        {
            var performanceefficiency = repo.Find(id);
            if (performanceefficiency == null)
            {
                return NotFound();
            }
            return new ObjectResult(performanceefficiency);
        }

        // POST: api/v1/performanceefficiency
        [HttpPost]
        public IActionResult Create([FromBody] PerformanceEfficiency performanceefficiency)
        {
            if (performanceefficiency == null)
            {
                return BadRequest();
            }
            repo.Add(performanceefficiency);
            return CreatedAtRoute("GetOeePerformanceEfficiency", new { id = performanceefficiency.PerformanceEfficiencyId }, performanceefficiency);
        }

        // PUT: api/v1/performanceefficiency/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PerformanceEfficiency performanceefficiency)
        {
            if (performanceefficiency == null || performanceefficiency.PerformanceEfficiencyId != id)
            {
                return BadRequest();
            }

            var performanceefficiencyItem = repo.Find(id);
            if (performanceefficiencyItem == null)
            {
                return NotFound();
            }

            repo.Update(performanceefficiency);
            return new NoContentResult();
        }

        // DELETE api/v1/performanceefficiency/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var performanceefficiencyItem = repo.Find(id);
            if (performanceefficiencyItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
