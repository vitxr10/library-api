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
            Status = BookStatusEnum.Available;
            CreatedAt = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Actor { get; private set; }
        public string ISBN { get; private set; }
        public int YearOfPublication { get; private set; }
        public BookStatusEnum Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public void Delete()
        {
            Status = BookStatusEnum.Unavailable;
            UpdatedAt = DateTime.Now;
        }

        public void Update(string title, string actor, string iSBN, int yearOfPublication)
        {
            Title = title;
            Actor = actor;
            ISBN = iSBN;
            YearOfPublication = yearOfPublication;
            UpdatedAt = DateTime.Now;
        }
    }
}
