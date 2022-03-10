using Mart_10_HW.Interfaces;
using Mart_10_HW.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mart_10_HW.Services
{
    class Service : Iservice
    {
        
        Library[] Iservice.library => new Library[0];
        public Library[] library;

        public void AddBook(string name, string authorname, int pages)
        {
            Book book = new Book(name, authorname, pages);
            library.AddBook(book);
        }

        public void RemoveBook(string no)
        {
            foreach (Library item in library)
            {
                for (int i = 0; i < item.Books; i++)
                {
                    if (item.Books[i].No == no.Trim().ToUpper())
                    {
                        item.Books[i] = null;

                        item.Books[i] = item.Books[item.Books.Length - 1];

                        Array.Resize(ref item.Books, item.Books.Length - 1);

                        return;
                    }
                }
            }
        }
    }
}
