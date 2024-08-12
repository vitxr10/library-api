using Library.Application.Queries.BooksQueries;
using Library.Core.Entities;
using Library.Core.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UnitTests.Application.Queries.BooksQueries
{
    public class GetBookByIdQueryHandlerTests
    {
        [Fact]
        public async void BookExists_Executed_ReturnBookDetailsViewModel()
        {
            // Arrange
            var book = new Book("Livro teste", "Ator teste", "10", 2000);

            var bookRepositoryMock = Substitute.For<IBookRepository>();
            bookRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(book);

            var getBookByIdQuery = new GetBookByIdQuery();
            var getBookByIdQueryHandler = new GetBookByIdQueryHandler(bookRepositoryMock);

            // Act
            var bookDetailsViewModel = await getBookByIdQueryHandler.Handle(getBookByIdQuery, new CancellationToken()); 

            // Assert
            Assert.NotNull(bookDetailsViewModel);
            await bookRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());

        }
    }
}
