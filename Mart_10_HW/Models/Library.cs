using System;
using System.Collections.Generic;
using System.Text;

namespace Mart_10_HW.Models
{
    class Library
    {
        List<Book> Books = new List<Book>();

        Book[] books = new Book[] { };
        public void AddBook(string name, string authorname, int pages)
        {
            //Array.Resize(ref books, books.Length + 1);
            //books[books.Length - 1] = new Book(name, authorname, pages);
            
        }


    }
}
