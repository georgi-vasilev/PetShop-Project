﻿using PetShop.Data.Controllers;
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
                    foreach (var a in animalController.SearchByTagsAnimal(specie,""))
                    {
                        Console.WriteLine(a.Specie + "||" + a.Breed);
                    };
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter specie: ");
                    string breed = Console.ReadLine();
                    foreach (var a in animalController.SearchByTagsAnimal("",breed))
                    {
                        Console.WriteLine(a.Specie + "||" + a.Breed);
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