using Library.Application.Commands.BooksCommands;
using Library.Core.Entities;
using Library.Core.Enums;
using Library.Core.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UnitTests.Application.Commands.BooksCommands
{
    public class CreateBookCommandHandlerTests
    {
        [Fact]
        public async void InputDataIsOk_Executed_CreateBook()
        {
            // Arrange
            var title = "Livro teste";
            var actor = "Ator teste";
            var isbn = "8,6";
            var year = 1990;

            var bookRepositoryMock = Substitute.For<IBookRepository>();

            var createBookCommand = new CreateBookCommand(title, actor, isbn, year);
            var createBookCommandHandler = new CreateBookCommandHandler(bookRepositoryMock);

            // Act
            var id = await createBookCommandHandler.Handle(createBookCommand, new CancellationToken());

            // Assert  
            await bookRepositoryMock.Received(1).CreateAsync(Arg.Any<Book>());
        }
    }
}
