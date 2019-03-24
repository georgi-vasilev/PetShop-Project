using PetShop.Data.Controllers;
using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Data.Views
{
    public class RemoveMenu
    {
        public static void Remove()
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
            Console.WriteLine("REMOVE MENU");
            Console.WriteLine("1:Employee");
            Console.WriteLine("2:Animal");
            Console.WriteLine("3:Client");
            Console.WriteLine("4:Cage");
            Console.WriteLine("5:Food");
            Console.WriteLine("0:Back");
        }

        public static void Redirect(int menu)
        {
            switch (menu)
            {
                case 1:
                    var employee = new Employee();
                    var employeeController = new EmployeeController();
                    Console.WriteLine("Enter EmployeeID:");
                    employee.Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please wait...");
                    employeeController.Remove(employee);
                    break;
                case 2:
                    var animal = new Animal();
                    var animalController = new AnimalController();
                    Console.WriteLine("Enter AnimalID:");
                    animal.Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please wait...");
                    animalController.RemoveAnimal(animal);
                    break;
                case 3:
                    var client = new Client();
                    var clientController = new ClientController();
                    Console.WriteLine("Enter ClientID:");
                    client.Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please wait...");
                    clientController.RemoveClient(client);
                    break;
                case 4:
                    var cage = new Cage();
                    var cageController = new CageController();
                    Console.WriteLine("Enter CageID:");
                    cage.Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please wait...");
                    cageController.RemoveCage(cage);
                    break;
                case 5:
                    var food = new Food();
                    var foodController = new FoodController();
                    Console.WriteLine("Enter FoodID:");
                    food.Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please wait...");
                    foodController.RemoveFood(food);
                    break;
                default:
                    Console.WriteLine("Invalid Number!");
                    break;
            }
        }
    }
}
