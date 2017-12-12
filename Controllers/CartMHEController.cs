using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OEEWebAPI.Models;
using OEEWebAPI.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OEEWebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class CartMHEController : Controller
    {
        // Constructor
        public CartMHEController(ICartMHERepository repository)
        {
            repo = repository;
        }
        public ICartMHERepository repo { get; set; }

        // GET: api/v1/cartmhe
        [HttpGet]
        public IEnumerable<CartMhe> GetAll()
        {
            return repo.GetAll();
        }

        // GET: api/v1/cartmhe{id}
        [HttpGet("{id}", Name = "GetCartMHE")]
        public IActionResult GetById(int id)
        {
            var cartmhe = repo.Find(id);
            if (cartmhe == null)
            {
                return NotFound();
            }
            return new ObjectResult(cartmhe);
        }

        // POST: api/v1/cartmhe
        [HttpPost]
        public IActionResult Create([FromBody] CartMhe cartmhe)
        {
            if (cartmhe == null)
            {
                return BadRequest();
            }
            repo.Add(cartmhe);
            return CreatedAtRoute("GetCartMHE", new { id = cartmhe.CartMheid }, cartmhe);
        }

        // PUT: api/v1/cartmhe/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CartMhe cartmhe)
        {
            if (cartmhe == null || cartmhe.CartMheid != id)
            {
                return BadRequest();
            }

            var cartmheItem = repo.Find(id);
            if (cartmheItem == null)
            {
                return NotFound();
            }

            repo.Update(cartmhe);
            return new NoContentResult();
        }

        // DELETE api/v1/cartmhe/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cartmheItem = repo.Find(id);
            if (cartmheItem == null)
            {
                return NotFound();
            }

            repo.Remove(id);
            return new NoContentResult();

        }
    }
}
