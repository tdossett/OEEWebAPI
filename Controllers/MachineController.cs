using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class MachineController : Controller
    {
        // Constructor
        public MachineController(IMachineRepository repository)
        {
            repo = repository;
        }
        public IMachineRepository repo { get; set; }

        // GET: api/v1/machine
        [HttpGet]
        public IEnumerable<Machine> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/machine{id}
        [HttpGet("{id}", Name = "GetMachine")]
        public IActionResult GetById(int id)
        {
            var machine = repo.Find(id);
            if (machine == null)
            {
                return NotFound();
            }
            return new ObjectResult(machine);
        }

        // POST: api/v1/machine
        [HttpPost]
        public IActionResult Create([FromBody] Machine machine)
        {
            if (machine == null)
            {
                return BadRequest();
            }
            repo.Add(machine);
            return CreatedAtRoute("GetMachine", new { id = machine.MachineId }, machine);
        }

        // PUT: api/v1/machine/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Machine machine)
        {
            if (machine == null || machine.MachineId != id)
            {
                return BadRequest();
            }

            var machineItem = repo.Find(id);
            if (machineItem == null)
            {
                return NotFound();
            }

            repo.Update(machine);
            return new NoContentResult();
        }

        // DELETE api/v1/machine/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var machineItem = repo.Find(id);
            if (machineItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
