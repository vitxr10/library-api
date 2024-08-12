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
    public class GetAllBooksQueryHandlerTests
    {
        [Fact]
        public async void ThreeBooksExists_Executed_ReturnThreeBooksViewModel()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book("Livro teste 1", "Ator teste 1", "10", 2000),
                new Book("Livro teste 2", "Ator teste 2", "10", 2010),
                new Book("Livro teste 3", "Ator teste 3", "10", 2020)
            };

            var bookRepositoryMock = Substitute.For<IBookRepository>();
            bookRepositoryMock.GetAllAsync().Returns(books);

            var getAllBooksQuery = new GetAllBooksQuery();
            var getAllBooksQueryHandler = new GetAllBooksQueryHandler(bookRepositoryMock);

            // Act
            var booksViewModel = await getAllBooksQueryHandler.Handle(getAllBooksQuery, new CancellationToken()); 

            // Assert
            Assert.NotNull(booksViewModel);
            Assert.NotEmpty(booksViewModel);
            Assert.Equal(books.Count(), booksViewModel.Count());
            await bookRepositoryMock.Received(1).GetAllAsync(); 
        }
    }
}
