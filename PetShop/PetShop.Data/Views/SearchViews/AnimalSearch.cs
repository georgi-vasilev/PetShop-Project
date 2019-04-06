using PetShop.Data.Controllers;
using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Data.Views.SearchViews
{
    public class AnimalSearch
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
            Console.WriteLine("1:Specie");
            Console.WriteLine("2:Breed");
            Console.WriteLine("3:Entry Date");
            Console.WriteLine("0:Back");
        }

        public static void Redirect(int menu)
        {
            var animal = new Animal();
            var animalController = new AnimalController();
            switch (menu)
            {
                case 1:
                    Console.Write("Enter specie: ");
                    string name = Console.ReadLine();
                    foreach (var a in animalController.)
                    {
                        
                    };
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid Number!");
                    break;
            }
        }
    }
}
