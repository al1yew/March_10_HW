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
                        ShowAllBooks(ref service);
                        break;
                    case 2:
                        AddBook(ref service);
                        break;
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
            Console.WriteLine("Welcome to Workers List.");
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
    }
}
