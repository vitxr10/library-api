using Library.Core.Entities;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;
        public BookRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            return book.Id;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dbContext.Books.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
