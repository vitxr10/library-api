using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class Book
    {
        public Book(int id, string title, string actor)
        {
            Id = id;
            Title = title;
            Actor = actor;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Actor { get; set; }
        public string ISBN { get; set; }
        public int YearOfPublication { get; set; }
    }
}
