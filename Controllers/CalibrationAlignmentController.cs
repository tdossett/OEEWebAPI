using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class CalibrationAlignmentController : Controller
    {
        // Constructor
        public CalibrationAlignmentController(ICalibrationAlignmentRepository repository)
        {
            repo = repository;
        }
        public ICalibrationAlignmentRepository repo { get; set; }

        // GET: api/v1/calibrationalignment
        [HttpGet]
        public IEnumerable<CalibrationAlignment> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/calibrationalignment{id}
        [HttpGet("{id}", Name = "GetCalibrationAlignment")]
        public IActionResult GetById(int id)
        {
            var calibrationalignment = repo.Find(id);
            if (calibrationalignment == null)
            {
                return NotFound();
            }
            return new ObjectResult(calibrationalignment);
        }

        // POST: api/v1/calibrationalignment
        [HttpPost]
        public IActionResult Create([FromBody] CalibrationAlignment calibrationalignment)
        {
            if (calibrationalignment == null)
            {
                return BadRequest();
            }
            repo.Add(calibrationalignment);
            return CreatedAtRoute("GetCalibrationAlignment", new { id = calibrationalignment.CalibrationAlignmentId }, calibrationalignment);
        }

        // PUT: api/v1/calibrationalignment/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CalibrationAlignment calibrationalignment)
        {
            if (calibrationalignment == null || calibrationalignment.CalibrationAlignmentId != id)
            {
                return BadRequest();
            }

            var calibrationalignmentItem = repo.Find(id);
            if (calibrationalignmentItem == null)
            {
                return NotFound();
            }

            repo.Update(calibrationalignment);
            return new NoContentResult();
        }

        // DELETE api/v1/calibrationalignment/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var calibrationalignmentItem = repo.Find(id);
            if (calibrationalignmentItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
