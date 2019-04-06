using PetShop.Data.Controllers;
using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Data.Views.SearchViews
{
    public class ClientSearch
    {
        public static void SearchBy()
        {
            int choice = 0;
            do
            {
                DisplayMenu();
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                Redirect(choice);
                Console.Clear();
            } while (choice != 0);
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Search by:");
            Console.WriteLine("1:Name");
            Console.WriteLine("2:SSN");
            Console.WriteLine("3:Adress");
            Console.WriteLine("0:Back");
        }

        public static void Redirect(int menu)
        {
            var client = new Client();
            var clientController = new ClientController();
            switch (menu)
            {
                case 1:
                    Console.Write("Enter name of client: ");
                    string name = Console.ReadLine();
                    foreach (var e in clientController.SearchByTagsClient(name,"",""))
                    {
                        Console.WriteLine(e.ClientName + "||" + e.ClientAddress);
                    };
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter SSN of client: ");
                    string ssn = Console.ReadLine();
                    foreach (var e in clientController.SearchByTagsClient("", ssn, ""))
                    {
                        Console.WriteLine(e.ClientName + "||" + e.ClientAddress);
                    };
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Enter adress of client: ");
                    string job = Console.ReadLine();
                    foreach (var e in clientController.SearchByTagsClient("", "", job))
                    {
                        Console.WriteLine(e.ClientName + "||" + e.ClientAddress);
                    };
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid Number!");
                    break;
            }
        }
    }
}
