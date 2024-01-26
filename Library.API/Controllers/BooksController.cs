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

            if (book == null)
            {
                return NotFound("O livro não foi encontrado.");
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateBookInputModel inputModel)
        {
            int id = _booksService.Create(inputModel);

            if (id == 0)
            {
                return BadRequest("Não foi possível adicionar o livro.");
            }

            return CreatedAtAction(nameof(GetById), new { id = inputModel.Id }, inputModel);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _booksService.Delete(id);

                return NoContent();
            }
            catch
            {
                return BadRequest("Não foi possível deletar o livro.");
            }
        }

    }
}
