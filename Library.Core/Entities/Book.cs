﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public class Book
    {
        public Book(int id, string title, string actor, string iSBN, int yearOfPublication)
        {
            Id = id;
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
    }
}
