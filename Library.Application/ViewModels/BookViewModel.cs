using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string actor)
        {
            Id = id;
            Title = title;
            Actor = actor;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Actor { get; private set; }
    }
}
