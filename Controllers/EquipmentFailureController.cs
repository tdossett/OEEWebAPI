using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class EquipmentFailureController : Controller
    {
        // Constructor
        public EquipmentFailureController(IEquipmentFailureRepository repository)
        {
            repo = repository;
        }
        public IEquipmentFailureRepository repo { get; set; }

        // GET: api/v1/equipmentfailure
        [HttpGet]
        public IEnumerable<EquipmentFailure> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/equipmentfailure{id}
        [HttpGet("{id}", Name = "GetEquipmentFailure")]
        public IActionResult GetById(int id)
        {
            var equipmentfailure = repo.Find(id);
            if (equipmentfailure == null)
            {
                return NotFound();
            }
            return new ObjectResult(equipmentfailure);
        }

        // POST: api/v1/equipmentfailure
        [HttpPost]
        public IActionResult Create([FromBody] EquipmentFailure equipmentfailure)
        {
            if (equipmentfailure == null)
            {
                return BadRequest();
            }
            repo.Add(equipmentfailure);
            return CreatedAtRoute("GetEquipmentFailure", new { id = equipmentfailure.EquipmentFailureId }, equipmentfailure);
        }

        // PUT: api/v1/equipmentfailure/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] EquipmentFailure equipmentfailure)
        {
            if (equipmentfailure == null || equipmentfailure.EquipmentFailureId != id)
            {
                return BadRequest();
            }

            var equipmentfailureItem = repo.Find(id);
            if (equipmentfailureItem == null)
            {
                return NotFound();
            }

            repo.Update(equipmentfailure);
            return new NoContentResult();
        }

        // DELETE api/v1/equipmentfailure/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var equipmentfailureItem = repo.Find(id);
            if (equipmentfailureItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }

}
