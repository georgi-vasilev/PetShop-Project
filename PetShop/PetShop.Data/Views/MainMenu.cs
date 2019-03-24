using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Data.Controllers;

namespace PetShop.Data.Views
{
    public class MainMenu
    {
        public static void Start()
        {
            int choice = 0;
            do
            {
                DisplayMenu();
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                Redirect(choice);
                Console.Clear();
            } while (choice!=0);

        }
        public static void DisplayMenu()
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("1:Add");
            Console.WriteLine("2:Sale");
            Console.WriteLine("3:Remove");
            Console.WriteLine("4:Search");
            Console.WriteLine("0:End");
        }
        public static void Redirect(int menu)
        {
            switch (menu)
            {
                case 1 :
                    AddMenu.Add();
                    break;
                case 2:
                    SaleMenu.MakeSale();
                    break;
                case 3:
                    RemoveMenu.Remove();
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
