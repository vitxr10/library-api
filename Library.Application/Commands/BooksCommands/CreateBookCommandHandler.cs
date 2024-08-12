using Library.Core.Entities;
using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.BooksCommands
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(request.Title, request.Actor, request.ISBN, request.YearOfPublication);

            return await _bookRepository.CreateAsync(book);
        }
    }
}
