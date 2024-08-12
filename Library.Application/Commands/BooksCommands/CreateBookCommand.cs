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
        public CreateBookCommand()
        {
            
        }
        public CreateBookCommand(string title, string actor, string iSBN, int yearOfPublication)
        {
            Title = title;
            Actor = actor;
            ISBN = iSBN;
            YearOfPublication = yearOfPublication;
        }

        public string Title { get; set; }
        public string Actor { get; set; }
        public string ISBN { get; set; }
        public int YearOfPublication { get; set; }
    }
}
