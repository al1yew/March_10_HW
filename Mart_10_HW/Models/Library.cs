using System;
using System.Collections.Generic;
using System.Text;

namespace Mart_10_HW.Models
{
    class Library
    {
        public List<Book> Books;

        public void AddBook(Book book)
        {
            Books.Add(book);
            return;
        }
        public Library()
        {
            Books = new List<Book>(0); // ili bez 0
        }

    }
}
