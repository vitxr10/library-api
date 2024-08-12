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

namespace Library.UnitTests.Core.Entities
{
    public class BookTests
    {
        [Fact]
        public async void BookExistsAndInputDataIsOk_Executed_UpdateBook()
        {
            // Arrange
            var book = new Book("Livro teste", "Ator teste", "10", 2000);

            var title = "Livro atualizado";
            var actor = "Ator atualizado";
            var isbn = "8,0";
            var year = 1990;

            var bookRepositoryMock = Substitute.For<IBookRepository>();
            bookRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(book);

            var updateBookCommand = new UpdateBookCommand(title, actor, isbn, year);
            var updateBookCommandHandler = new UpdateBookCommandHandler(bookRepositoryMock);

            // Act
            await updateBookCommandHandler.Handle(updateBookCommand, new CancellationToken());

            // Assert
            Assert.Equal(title, book.Title);
            Assert.Equal(actor, book.Actor);
            Assert.Equal(isbn, book.ISBN);
            Assert.Equal(year, book.YearOfPublication);
            await bookRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await bookRepositoryMock.Received(1).SaveAsync();
        }

        [Fact]
        public async void BookExists_Executed_DeleteBook()
        {
            // Arrange
            var book = new Book("Livro teste", "Ator teste", "10", 2000);

            var bookRepositoryMock = Substitute.For<IBookRepository>();
            bookRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(book);

            var deleteBookCommand = new DeleteBookCommand();
            var deleteBookCommandHandler = new DeleteBookCommandHandler(bookRepositoryMock);

            // Act
            await deleteBookCommandHandler.Handle(deleteBookCommand, new CancellationToken());

            // Assert
            Assert.Equal(BookStatusEnum.Unavailable, book.Status);
            await bookRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await bookRepositoryMock.Received(1).SaveAsync();
        }
    }
}
