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
                    Console.Write(String.Format("||{0,2}|", "Id"));
                    Console.Write(String.Format("{0,15}|", "Client Name"));
                    Console.Write(String.Format("{0,15}|", "Client Adress"));
                    Console.Write(String.Format("{0,11}|", "SSN"));
                    Console.WriteLine();
                    Console.WriteLine(new String('-', 52));
                    foreach (var c in clientController.SearchByTagsClient(name,"",""))
                    {
                        Console.Write(String.Format("||{0,2}|", c.Id));
                        Console.Write(String.Format("{0,15}|", c.ClientName));
                        Console.Write(String.Format("{0,15}|", c.ClientAddress));
                        Console.Write(String.Format("{0,11}||", c.Ssn));
                        Console.WriteLine();
                        Console.WriteLine(new String('-', 50));
                    };
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter SSN of client: ");
                    string ssn = Console.ReadLine();
                    Console.Write(String.Format("||{0,2}|", "Id"));
                    Console.Write(String.Format("{0,15}|", "Client Name"));
                    Console.Write(String.Format("{0,15}|", "Client Adress"));
                    Console.Write(String.Format("{0,11}||", "SSN"));
                    Console.WriteLine();
                    Console.WriteLine(new String('-', 50));
                    foreach (var c in clientController.SearchByTagsClient("", ssn, ""))
                    {
                        Console.Write(String.Format("||{0,2}|", c.Id));
                        Console.Write(String.Format("{0,15}|", c.ClientName));
                        Console.Write(String.Format("{0,15}|", c.ClientAddress));
                        Console.Write(String.Format("{0,11}||", c.Ssn));
                        Console.WriteLine();
                        Console.WriteLine(new String('-', 50));
                    };
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Enter adress of client: ");
                    string job = Console.ReadLine();
                    Console.Write(String.Format("||{0,2}|", "Id"));
                    Console.Write(String.Format("{0,15}|", "Client Name"));
                    Console.Write(String.Format("{0,15}|", "Client Adress"));
                    Console.Write(String.Format("{0,11}||", "SSN"));
                    Console.WriteLine();
                    Console.WriteLine(new String('-', 50));
                    foreach (var c in clientController.SearchByTagsClient("", "", job))
                    {
                        Console.Write(String.Format("||{0,2}|", c.Id));
                        Console.Write(String.Format("{0,15}|", c.ClientName));
                        Console.Write(String.Format("{0,15}|", c.ClientAddress));
                        Console.Write(String.Format("{0,11}||", c.Ssn));
                        Console.WriteLine();
                        Console.WriteLine(new String('-', 50));
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
