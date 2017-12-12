using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class MaterialController : Controller
    {
        // Constructor
        public MaterialController(IMaterialRepository repository)
        {
            repo = repository;
        }
        public IMaterialRepository repo { get; set; }

        // GET: api/v1/material
        [HttpGet]
        public IEnumerable<Material> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/material{id}
        [HttpGet("{id}", Name = "GetMaterial")]
        public IActionResult GetById(int id)
        {
            var material = repo.Find(id);
            if (material == null)
            {
                return NotFound();
            }
            return new ObjectResult(material);
        }

        // POST: api/v1/material
        [HttpPost]
        public IActionResult Create([FromBody] Material material)
        {
            if (material == null)
            {
                return BadRequest();
            }
            repo.Add(material);
            return CreatedAtRoute("GetMaterial", new { id = material.MaterialId }, material);
        }

        // PUT: api/v1/material/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Material material)
        {
            if (material == null || material.MaterialId != id)
            {
                return BadRequest();
            }

            var materialItem = repo.Find(id);
            if (materialItem == null)
            {
                return NotFound();
            }

            repo.Update(material);
            return new NoContentResult();
        }

        // DELETE api/v1/material/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var materialItem = repo.Find(id);
            if (materialItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
