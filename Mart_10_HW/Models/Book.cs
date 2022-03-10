using System;
using System.Collections.Generic;
using System.Text;

namespace Mart_10_HW.Models
{
    class Book
    {
        private int pages;

        public Book(string name, string authorname, int pages)
        {
            Name = name;
            AuthorName = authorname;
            this.pages = pages;
        }

        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }

    }
}
