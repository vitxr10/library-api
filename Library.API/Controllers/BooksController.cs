using Library.Application.Commands.BooksCommands;
using Library.Application.InputModels;
using Library.Application.Queries.BooksQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllBooksQuery();

            var books = await _mediator.Send(query);

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var query = new GetBookByIdQuery(id);

                var books = await _mediator.Send(query);

                return Ok(books);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBookCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateBookCommand command)
        {
            try
            {
                command.Id = id;

                await _mediator.Send(command);

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteBookCommand(id);

                await _mediator.Send(command);

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
