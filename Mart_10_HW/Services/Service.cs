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

        public void RemoveBook(string bookcode)
        {
            foreach (Library item in library)
            {
                for (int i = 0; i < library.Length; i++)
                {
                    if (item.Books[i].Code == bookcode.Trim().ToUpper())
                    {
                        item.Books.RemoveAt(i);
                        item.Books[i] = item.Books[item.Books.Count - 1];
                        return;
                    }
                }
            }
        }

        public List<string> FindAllBooksByName(string name) 
        {
            List<string> founded = new List<string>();
            foreach (Library item in library)
            {
                for (int i = 0; i < library.Length; i++)
                {
                    if ((item.Books[i].Name.Trim().ToUpper() == name.Trim().ToUpper()))
                    {
                        founded.Add(item.Books[i].ToString());
                    }
                }
            }
            return founded;
        }

        public void RemoveAllBookByName(string name)
        {
            foreach (var item in library)
            {
                for (int i = 0; i < library.Length; i++)
                {
                    if (item.Books[i].Name == name.Trim().ToUpper())
                    {
                        item.Books.RemoveAt(i);
                        item.Books[i] = item.Books[item.Books.Count - 1];
                        return;
                    }
                }
            }
            
        }

        public List<string> FindAllBooksByPageCountRange(int a, int b)
        {
            List<string> founded = new List<string>();
            foreach (var item in library)
            {
                for (int i = 0; i < library.Length; i++)
                {
                    if (item.Books[i].PageCount > a && item.Books[i].PageCount < b)
                    {
                        founded.Add(item.Books[i].ToString());
                    }
                }
            }
            return founded;
        }

        void Iservice.FindAllBooksByName(string name)
        {
            throw new NotImplementedException();
        }

        void Iservice.FindAllBooksByPageCountRange(int a, int b)
        {
            throw new NotImplementedException();
        }
    }
}
