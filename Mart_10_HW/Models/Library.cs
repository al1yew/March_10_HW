using System;
using System.Collections.Generic;
using System.Text;

namespace Mart_10_HW.Models
{
    class Library
    {
        List<Book> Books = new List<Book>();

        public void AddBook(string name, string authorname, int pages)
        {
            Books.Add(new Book(name, authorname, pages));
        }


    }
}
