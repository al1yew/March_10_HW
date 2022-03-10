using System;
using System.Collections.Generic;
using System.Text;

namespace Mart_10_HW.Models
{
    class Book
    {
        private int Pages;

        public Book(string name, string authorname, int pages)
        {
            Name = name;
            AuthorName = authorname;
            Pages = pages;

        }
        private static int codenum = 1;
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }

        public override string ToString()
        {
            return $"Book name: {Name}\n" +
                $"Books pages count: {pages}\n" +
                $"Books Author: {AuthorName}\n" +
                $"Code: {Name.Substring(0,2)}{codenum}";
        }

    }
}
