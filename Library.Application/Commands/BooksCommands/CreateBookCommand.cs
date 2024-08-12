using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.BooksCommands
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; private set; }
        public string Actor { get; private set; }
        public string ISBN { get; private set; }
        public int YearOfPublication { get; private set; }
    }
}
