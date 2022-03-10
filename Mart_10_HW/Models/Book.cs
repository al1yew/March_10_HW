using System;
using System.Collections.Generic;
using System.Text;

namespace Mart_10_HW.Models
{
    class Book
    {

        public string Code { get; set; }
        public Book(string name, string authorname, int pages)
        {
            Name = name;
            AuthorName = authorname;
            PageCount = pages;
            Code = Name.Substring(0, 2);
            codenum++;
        }

        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }

        private static int codenum = 1;

        public override string ToString()
        {
            return $"Book name: {Name}\n" +
                $"Books pages count: {PageCount}\n" +
                $"Books Author: {AuthorName}\n" +
                $"Code: {Code}{codenum}";
        }

    }
}
