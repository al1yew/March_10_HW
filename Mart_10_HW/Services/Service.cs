using Mart_10_HW.Interfaces;
using Mart_10_HW.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mart_10_HW.Services
{
    class Service : Iservice
    {
        public Library[] library;
        public Service()
        {
            library = new Library[0];
        }
        Library[] Iservice.library => throw new NotImplementedException();

        public void AddBook(string name, string authorname, int pages)
        {
            Library library = null;
            Book book = new Book(name, authorname, pages);
            library.AddBook(book);
        }
    }
}
