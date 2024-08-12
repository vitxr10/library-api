using Library.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.BooksQueries
{
    public class GetAllBooksQuery : IRequest<List<BookViewModel>>
    {
    }
}
