using PetShop.Data.Views.SearchViews;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Data.Views
{
    public class SearchMenu
    {

        public static void Search()
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
            Console.WriteLine("SEARCH MENU");
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
                    EmployeeSearch.SearchBy();
                    break;
            }
        }
    }
}
