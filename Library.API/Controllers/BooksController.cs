using Library.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //return NotFound();
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Livro livro)
        {
            //return BadRequest();
            return CreatedAtAction(nameof(GetById), new { id = livro.Id }, livro);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //return BadRequest();
            return NoContent();
        }

    }
}
