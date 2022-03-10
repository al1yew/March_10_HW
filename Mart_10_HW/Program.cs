using Mart_10_HW.Models;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Mart_10_HW
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.WriteLine($"\n===== Hello dear user =====\n" + "\n" +
                    $"1. -- Show all Books\n" +
                    $"2. -- Add Book\n" +
                    $"3. -- Edit Book\n" +
                    $"4. -- Remove Book\n" +
                    $"5. -- Search Book by parameters\n" +
                    $"6. -- Find Book by appropriate page count\n" +
                    $"7. -- Exit\n" +
                    $"+_+_+_+_+_+_+_+_+_+_+_+_+ ");

                string userchoice = Console.ReadLine();
                byte userchoicenum;

                while (!byte.TryParse(userchoice, out userchoicenum) || userchoicenum < 1 || userchoicenum > 11)
                {
                    Console.WriteLine("\nYou need to choose numbers from 1 to 7 without using any other symbols.\nTry again\n");
                    userchoice = Console.ReadLine();
                }
                Console.Clear();
                Console.WriteLine($"-- We are preparing the process...");
                switch (userchoicenum)
                {
                    case 1:
                        AddBook();
                        break;
                    //case 2:
                    //    AddDepartment(ref humanResourceManager);
                    //    break;
                    //case 3:
                    //    EditDepartment(ref humanResourceManager);
                    //    break;
                    //case 4:
                    //    GetDepartmentWorkers(ref humanResourceManager);
                    //    break;
                    //case 5:
                    //    GetWorkersList(ref humanResourceManager);
                    //    break;
                    //case 6:
                    //    AddEmployee(ref humanResourceManager);
                    //    break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Thanks for visiting. All the best.");
                        return;
                }
            } while (true);
        }
        static void AddBook()
        {
            Library library = new Library();

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

            Console.WriteLine("\nWrite down the salary limit that you are going to implement");
            string pagecount = Console.ReadLine();

            while (!Regex.IsMatch(pagecount, @"^\d+$"))
            {
                Console.WriteLine($"\nSorry but page count must be in numbers!");
                pagecount = Console.ReadLine();
            }

            int pages = int.Parse(pagecount);

            library.AddBook(name, authorname, pages);

            Console.WriteLine("BYE!");
        }
    }
}
