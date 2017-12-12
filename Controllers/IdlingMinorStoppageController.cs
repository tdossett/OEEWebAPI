using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class IdlingMinorStoppageController : Controller
    {
        // Constructor
        public IdlingMinorStoppageController(IIdlingMinorStoppageRepository repository)
        {
            repo = repository;
        }
        public IIdlingMinorStoppageRepository repo { get; set; }

        // GET: api/v1/idlingminorstoppage
        [HttpGet]
        public IEnumerable<IdlingMinorStoppage> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/idlingminorstoppage{id}
        [HttpGet("{id}", Name = "GetIdlingMinorStoppage")]
        public IActionResult GetById(int id)
        {
            var idlingminorstoppage = repo.Find(id);
            if (idlingminorstoppage == null)
            {
                return NotFound();
            }
            return new ObjectResult(idlingminorstoppage);
        }

        // POST: api/v1/idlingminorstoppage
        [HttpPost]
        public IActionResult Create([FromBody] IdlingMinorStoppage idlingminorstoppage)
        {
            if (idlingminorstoppage == null)
            {
                return BadRequest();
            }
            repo.Add(idlingminorstoppage);
            return CreatedAtRoute("GetIdlingMinorStoppage", new { id = idlingminorstoppage.IdlingMinorStoppageId }, idlingminorstoppage);
        }

        // PUT: api/v1/idlingminorstoppage/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] IdlingMinorStoppage idlingminorstoppage)
        {
            if (idlingminorstoppage == null || idlingminorstoppage.IdlingMinorStoppageId != id)
            {
                return BadRequest();
            }

            var idlingminorstoppageItem = repo.Find(id);
            if (idlingminorstoppageItem == null)
            {
                return NotFound();
            }

            repo.Update(idlingminorstoppage);
            return new NoContentResult();
        }

        // DELETE api/v1/idlingminorstoppage/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var idlingminorstoppageItem = repo.Find(id);
            if (idlingminorstoppageItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
