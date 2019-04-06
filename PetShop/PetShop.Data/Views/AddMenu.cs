using System;
using PetShop.Data.Controllers;
using PetShop.Data.Models;

namespace PetShop.Data.Views
{
    /// <summary>
    /// Class that contains all different option to add information to the database
    /// </summary>
    public class AddMenu
    {
        /// <summary>
        /// Function that gives the user opportunity
        /// to choose what they would like to add into
        /// the database.
        /// </summary>
        public static void Add()
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

        /// <summary>
        /// Display function that visualize all possible
        /// options to add information to the database
        /// </summary>
        public static void DisplayMenu()
        {
            Console.WriteLine("ADD MENU");
            Console.WriteLine("1:Employee");
            Console.WriteLine("2:Animal");
            Console.WriteLine("3:Client");
            Console.WriteLine("4:Cage");
            Console.WriteLine("5:Food");
            Console.WriteLine("0:Back");
        }
        
        /// <summary>
        /// Function using switch operator with different cases
        /// depending on the user to add different kind of information
        /// to the database
        /// </summary>
        /// <param name="menu">The argument "menu" is read from the console in order to be used in switch operator</param>
        public static void Redirect(int menu)
        {
            switch (menu)
            {
                case 1:
                    var employee = new Employee();
                    var employeeController = new EmployeeController();
                    Console.Write("Enter Name: ");
                    employee.EmployeeName = Console.ReadLine();
                    Console.Write("Enter SSN: ");
                    employee.Ssn = Console.ReadLine();
                    Console.Write("Enter Salary: ");
                    employee.Salary = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Job Type: ");
                    employee.JobType = Console.ReadLine();
                    Console.WriteLine("Please wait...");
                    employeeController.AddEmployee(employee);
                    break;
                case 2:
                    var animal = new Animal();
                    int invalidNumber = 1;
                    var animalController = new AnimalController();
                    var cController = new CageController();
                    var fController = new FoodController();
                    Console.Write("Enter Specie: ");
                    animal.Specie = Console.ReadLine();
                    Console.Write("Enter Breed: ");
                    animal.Breed = Console.ReadLine();
                    Console.Write("Enter Sex: ");
                    animal.Sex = Console.ReadLine();
                    Console.Write("Enter FoodID: ");
                    var foods  = fController.GetAllFoods();
                    do
                    {
                        animal.FoodId = int.Parse(Console.ReadLine());
                        foreach (var f in foods)
                        {
                            if (f.Id == animal.FoodId) { invalidNumber = 0; };
                        }
                        if (invalidNumber == 1) { Console.Write("Invalid ID, please enter a new one: "); }
                    } while (invalidNumber == 1);
                    invalidNumber = 1;
                    animal.EntryDate = DateTime.Now;
                    Console.Write("Enter CageID: ");
                    var cages = cController.GetAllCages();
                    do
                    {
                        animal.CageId = int.Parse(Console.ReadLine());
                        foreach (var c in cages)
                        {
                            if (c.Id == animal.CageId) { invalidNumber = 0; };
                        }
                        if (invalidNumber == 1) { Console.Write("Invalid ID, please enter a new one: "); }
                    } while (invalidNumber == 1);
                    invalidNumber = 1;
                    Console.WriteLine("Please wait...");
                    animalController.AddAnimal(animal);
                    break;
                case 3:
                    var client = new Client();
                    var clientController = new ClientController();
                    Console.WriteLine("Enter Name:");
                    client.ClientName = Console.ReadLine();
                    Console.WriteLine("Enter SSN:");
                    client.Ssn = Console.ReadLine();
                    Console.WriteLine("Enter Address:");
                    client.ClientAddress = Console.ReadLine();
                    Console.WriteLine("Please wait...");
                    clientController.AddClient(client);
                    break;
                case 4:
                    var cage = new Cage();
                    var cageController = new CageController();
                    Console.WriteLine("Enter Type:");
                    cage.CageType = Console.ReadLine();
                    Console.WriteLine("Enter Capacity:");
                    cage.Capacity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please wait...");
                    cageController.AddCage(cage);
                    break;
                case 5:
                    var food = new Food();
                    var foodController = new FoodController();
                    Console.WriteLine("Enter Type:");
                    food.FoodType = Console.ReadLine();
                    Console.WriteLine("Enter Brand:");
                    food.Brand = Console.ReadLine();
                    Console.WriteLine("Enter Quantity:");
                    food.Quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please wait...");
                    foodController.AddFood(food);
                    break;
                default:
                    Console.WriteLine("Invalid Number!");
                    break;
            }
        }
    }
}
