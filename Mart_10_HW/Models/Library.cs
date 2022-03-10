using System;
using System.Collections.Generic;
using System.Text;

namespace Mart_10_HW.Models
{
    class Library
    {
        List<Book> Books;

        public void AddBook(Book book)
        {
            Books.Add(book);
            return;
        }


    }
}
