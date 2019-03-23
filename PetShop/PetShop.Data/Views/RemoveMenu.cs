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
                    Console.WriteLine("Enter ID:");
                    Console.ReadLine();
                    Console.WriteLine("Record Removed, press any key to continue.");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Menu 2");
                    break;
                case 3:
                    Console.WriteLine("Menu 3");
                    break;
                case 4:
                    Console.WriteLine("Menu 4");
                    break;
                default:
                    Console.WriteLine("Invalid Number!");
                    break;
            }
        }
    }
}
