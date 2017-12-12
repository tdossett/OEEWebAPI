using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class SetupAdjustmentController : Controller
    {
        // Constructor
        public SetupAdjustmentController(ISetupAdjustmentRepository repository)
        {
            repo = repository;
        }
        public ISetupAdjustmentRepository repo { get; set; }

        // GET: api/v1/setupadjustment
        [HttpGet]
        public IEnumerable<SetupAdjustment> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/setupadjustment{id}
        [HttpGet("{id}", Name = "GetSetupAdjustment")]
        public IActionResult GetById(int id)
        {
            var setupadjustment = repo.Find(id);
            if (setupadjustment == null)
            {
                return NotFound();
            }
            return new ObjectResult(setupadjustment);
        }

        // POST: api/v1/setupadjustment
        [HttpPost]
        public IActionResult Create([FromBody] SetupAdjustment setupadjustment)
        {
            if (setupadjustment == null)
            {
                return BadRequest();
            }
            repo.Add(setupadjustment);
            return CreatedAtRoute("GetSetuAdjustment", new { id = setupadjustment.SetupAdjustmentId }, setupadjustment);
        }

        // PUT: api/v1/setupadjustment/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SetupAdjustment setupadjustment)
        {
            if (setupadjustment == null || setupadjustment.SetupAdjustmentId != id)
            {
                return BadRequest();
            }

            var setupadjustmentItem = repo.Find(id);
            if (setupadjustmentItem == null)
            {
                return NotFound();
            }

            repo.Update(setupadjustment);
            return new NoContentResult();
        }

        // DELETE api/v1/setupadjustment/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var setupadjustmentItem = repo.Find(id);
            if (setupadjustmentItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
