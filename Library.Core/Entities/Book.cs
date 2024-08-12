using Library.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class Book
    {
        public Book(string title, string actor, string iSBN, int yearOfPublication)
        {
            Title = title;
            Actor = actor;
            ISBN = iSBN;
            YearOfPublication = yearOfPublication;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Actor { get; private set; }
        public string ISBN { get; private set; }
        public int YearOfPublication { get; private set; }
        public BookStatusEnum Status { get; private set; }

        public void Delete()
        {
            Status = BookStatusEnum.Unavailable;
        }

        public void Update(string title, string actor, string iSBN, int yearOfPublication)
        {
            Title = title;
            Actor = actor;
            ISBN = iSBN;
            YearOfPublication = yearOfPublication;
        }
    }
}
