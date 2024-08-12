using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.BooksCommands
{
    public class UpdateBookCommand : IRequest
    {
        public UpdateBookCommand()
        {
            
        }
        public UpdateBookCommand(string title, string actor, string iSBN, int yearOfPublication)
        {
            Title = title;
            Actor = actor;
            ISBN = iSBN;
            YearOfPublication = yearOfPublication;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Actor { get; set; }
        public string ISBN { get; set; }
        public int YearOfPublication { get; set; }
    }
}
