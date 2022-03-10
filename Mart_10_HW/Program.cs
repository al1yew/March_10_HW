using Mart_10_HW.Models;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Mart_10_HW.Services;

namespace Mart_10_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();
            do
            {
                Console.WriteLine($"\n===== Hello dear user =====\n" + "\n" +
                    $"1. -- Show all Books\n" +
                    $"2. -- Add Book\n" +
                    $"3. -- Remove Book\n" +
                    $"4. -- Search Book by parameters\n" +
                    $"5. -- Find Book by appropriate page count\n" +
                    $"6. -- Continuous remover" +
                    $"7. -- Exit\n" +
                    $"+_+_+_+_+_+_+_+_+_+_+_+_+ ");

                string userchoice = Console.ReadLine();
                byte userchoicenum;

                while (!byte.TryParse(userchoice, out userchoicenum) || userchoicenum < 1 || userchoicenum > 8)
                {
                    Console.WriteLine("\nYou need to choose numbers from 1 to 6 without using any other symbols.\nTry again\n");
                    userchoice = Console.ReadLine();
                }
                Console.Clear();
                Console.WriteLine($"-- We are preparing the process...");
                switch (userchoicenum)
                {
                    case 1:
                        ShowAllBooks(ref service);
                        break;
                    case 2:
                        AddBook(ref service);
                        break;
                    case 3:
                        RemoveBook(ref service);
                        break;
                    case 4:
                        FindAllBooksByName(ref service);
                        break;
                    case 5:
                        FindAllBooksByPageCountRange(ref service);
                        break;
                    case 6:
                        RemoveAllBookByName(ref service);
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Thanks for visiting. All the best.");
                        return;
                }
            } while (true);
        }

        static void AddBook(ref Service service)
        {
            Console.WriteLine("\nPlease write down name of Book that you are going to add:");
            string name = Console.ReadLine();

            while (!Regex.IsMatch(name, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(name, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"\nGiven name {name} for Book is not appropriate.\nIt MUST NOT contain something other than letters or whitespaces (only between words).");
                name = Console.ReadLine();
            }

            Console.WriteLine("\nWrite down the Author Name:");
            string authorname = Console.ReadLine();

            while (!Regex.IsMatch(authorname, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(authorname, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"\nGiven Author Name {authorname} for Book is not appropriate.\nIt MUST NOT contain something other than letters or whitespaces (only between words).");
                authorname = Console.ReadLine();
            }

            Console.WriteLine("\nWrite down the page count");
            string pagecount = Console.ReadLine();

            while (!Regex.IsMatch(pagecount, @"^\d+$"))
            {
                Console.WriteLine($"\nSorry but page count must be in numbers!");
                pagecount = Console.ReadLine();
            }

            int pages = int.Parse(pagecount);

            service.AddBook(name, authorname, pages);

            Console.WriteLine("BYE!");
        }
        static void ShowAllBooks(ref Service service)
        {
            Console.WriteLine("Welcome to Books List.");
            if (service.library.Length > 0)
            {
                for (int i = 0; i < service.library.Length; i++)
                {
                    Console.WriteLine(service.library[i]);
                }
            }
            else
            {
                Console.WriteLine($"There are no Books. Please add them first of all.");
                return;
            }
        }
        static void RemoveBook(ref Service service)
        {
            Console.WriteLine("Welcome to Book remover.");
            if (service.library.Length > 0)
            {
                for (int i = 0; i < service.library.Length; i++)
                {
                    Console.WriteLine(service.library[i]);
                }
            }
            else
            {
                Console.WriteLine($"There are no Books. Please add them first of all.");
                return;
            }

            Console.WriteLine("Write book's code:");
            string bookcode = Console.ReadLine();

            while (!Regex.IsMatch(bookcode, "^.*[a-zA-Z]{2}[0-9].*$"))
            {
                Console.WriteLine($"\nSorry but code is wrong!");
                bookcode = Console.ReadLine();
            }

            service.RemoveBook(bookcode);
        }
        static void FindAllBooksByName(ref Service service)
        {
            Console.WriteLine("\nPlease write down name of Book that you are going to find:");
            string name = Console.ReadLine();

            while (!Regex.IsMatch(name, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(name, @"^\S+(?: \S+)*$"))
            {
                Console.WriteLine($"\nGiven name {name} for Book is not appropriate.\nIt MUST NOT contain something other than letters or whitespaces (only between words).");
                name = Console.ReadLine();
            }

            foreach (var item in service.FindAllBooksByName(name))
            {
                Console.WriteLine(item);
            }
        }

        static void RemoveAllBookByName(ref Service service) 
        {
            while (true)
            {
                Console.WriteLine("\nPlease write down name of Book that you are going to remove:");
                string name = Console.ReadLine();

                while (!Regex.IsMatch(name, @"\A[\p{L}\s]+\Z") || !Regex.IsMatch(name, @"^\S+(?: \S+)*$"))
                {
                    Console.WriteLine($"\nGiven name {name} for Book is not appropriate.\nIt MUST NOT contain something other than letters or whitespaces (only between words).");
                    name = Console.ReadLine();
                }
                Console.WriteLine("Want to remove again? y/n");
                string removeagain = Console.ReadLine();

                while (Regex.IsMatch(removeagain, "^(?:Y\b|N\b)"))
                {
                    Console.WriteLine("Write only Y or N");
                    removeagain = Console.ReadLine();
                }

                if (removeagain == "y")
                {
                    removeagain = Console.ReadLine();
                }

                foreach (var item in service.FindAllBooksByName(name))
                {
                    Console.WriteLine(item);
                }
                break;
            }
            

        }

        static void FindAllBooksByPageCountRange(ref Service service) 
        {
            Console.WriteLine("Write the pages count of beginning of period");

            string aa = Console.ReadLine();

            while (!Regex.IsMatch(aa, @"^\d+$"))
            {
                Console.WriteLine($"\nSorry but page count must be in numbers!");
                aa = Console.ReadLine();
            }

            int a = int.Parse(aa);

            Console.WriteLine("Write the pages count of end of period");

            string bb = Console.ReadLine();

            while (!Regex.IsMatch(bb, @"^\d+$"))
            {
                Console.WriteLine($"\nSorry but page count must be in numbers!");
                bb = Console.ReadLine();
            }
            int b = int.Parse(bb);
            service.FindAllBooksByPageCountRange(a, b);
        }
    }
}
