using Library.API.Models;
using Library.Application.InputModels;
using Library.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService booksService) 
        {
            _booksService = booksService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _booksService.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _booksService.GetById(id);
            //return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateBookInputModel inputModel)
        {
            int id = _booksService.Create(inputModel);
            //return BadRequest();
            return CreatedAtAction(nameof(GetById), new { id = inputModel.Id }, inputModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _booksService.Delete(id);
            //return BadRequest();
            return NoContent();
        }

    }
}
