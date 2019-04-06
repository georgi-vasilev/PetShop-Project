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
                    string specie = Console.ReadLine();
                    Console.Write(String.Format("||{0,2}|", "Id"));
                    Console.Write(String.Format("{0,15}|", "Breed"));
                    Console.Write(String.Format("{0,3}|", "Sex"));
                    Console.Write(String.Format("{0,11}|", "Date"));
                    Console.Write(String.Format("{0,6}|", "FoodID"));
                    Console.Write(String.Format("{0,6}||", "Cage"));
                    Console.WriteLine();
                    Console.WriteLine(new String('-', 52));
                    foreach (var a in animalController.SearchByTagsAnimal(specie,""))
                    {
                        Console.Write(String.Format("||{0,2}|", a.Id));
                        Console.Write(String.Format("{0,15}|", a.Breed));
                        Console.Write(String.Format("{0,3}|", a.Sex));
                        Console.Write(String.Format("{0,11}|", a.EntryDate.ToString("dd/MM/yyyy")));
                        Console.Write(String.Format("{0,6}|", a.FoodId));
                        Console.Write(String.Format("{0,6}||", a.CageId));
                        Console.WriteLine();
                        Console.WriteLine(new String('-', 52));
                    };
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter specie: ");
                    string breed = Console.ReadLine();
                    Console.Write(String.Format("||{0,2}|", "Id"));
                    Console.Write(String.Format("{0,15}|", "Breed"));
                    Console.Write(String.Format("{0,3}|", "Sex"));
                    Console.Write(String.Format("{0,11}|", "Date"));
                    Console.Write(String.Format("{0,6}|", "FoodID"));
                    Console.Write(String.Format("{0,6}||", "Cage"));
                    Console.WriteLine();
                    Console.WriteLine(new String('-', 52));
                    foreach (var a in animalController.SearchByTagsAnimal("",breed))
                    {
                        Console.Write(String.Format("||{0,2}|", a.Id));
                        Console.Write(String.Format("{0,15}|", a.Breed));
                        Console.Write(String.Format("{0,3}|", a.Sex));
                        Console.Write(String.Format("{0,11}|", a.EntryDate.ToString("dd/MM/yyyy")));
                        Console.Write(String.Format("{0,6}|", a.FoodId));
                        Console.Write(String.Format("{0,6}||", a.CageId));
                        Console.WriteLine();
                        Console.WriteLine(new String('-', 52));
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
