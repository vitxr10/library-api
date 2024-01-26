using Library.Application.InputModels;
using Library.Application.Services.Interfaces;
using Library.Application.ViewModels;
using Library.Core.Entities;
using Library.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.Implementations
{
    public class BooksService : IBooksService
    {
        private readonly LibraryDbContext _dbContext;
        public BooksService(LibraryDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public List<BookViewModel> GetAll()
        {
            var books = _dbContext.Books.Select(b => new BookViewModel(b.Id, b.Title, b.Actor)).ToList();

            return books;
        }

        public BookDetailsViewModel GetById(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);

            BookDetailsViewModel bookDetails = null;

            if (book != null)
            {
                bookDetails = new BookDetailsViewModel(book.Id, book.Title, book.Actor, book.ISBN, book.YearOfPublication);
            }

            return bookDetails;
        }

        public int Create(CreateBookInputModel inputModel)
        {
            var book = new Book(inputModel.Id, inputModel.Title, inputModel.Actor, inputModel.ISBN, inputModel.YearOfPublication);

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return book.Id;
        }

        public void Delete(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}
