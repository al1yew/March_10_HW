using Mart_10_HW.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mart_10_HW.Interfaces
{
    interface Iservice
    {
        Library[] library { get; }
        void AddBook(string name, string authorname, int pages);
        void RemoveBook(string bookcode);
        void FindAllBooksByName(string name);
        void RemoveAllBookByName(string name);
        void FindAllBooksByPageCountRange(int a, int b)
    }
}
