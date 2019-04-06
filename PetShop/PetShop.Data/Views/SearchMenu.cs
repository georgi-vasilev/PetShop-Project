using PetShop.Data.Views.SearchViews;
using System;

namespace PetShop.Data.Views
{
    /// <summary>
    /// Class for search menu.
    /// </summary>
    public class SearchMenu
    {
        /// <summary>
        /// Function allowing the user to choose what they would
        /// like to search
        /// </summary>

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

        /// <summary>
        /// Simple function displaying all search options
        /// </summary>
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
        
        /// <summary>
        /// Function to redirect the user when they choose what they would like to search.
        /// </summary>
        /// <param name="menu">This arguement is given number by the user
        /// in order to be used in switch construction </param>
        public static void Redirect(int menu)
        {
            switch (menu)
            {
                case 1:
                    EmployeeSearch.SearchBy();
                    break;
                case 2:
                    AnimalSearch.SearchBy();
                    break;
                case 3:
                    ClientSearch.SearchBy();
                    break;
                case 4:
                    CageSearch.Search();
                    break;
                case 5:
                    FoodSearch.Search();
                    break;
                default:
                    Console.WriteLine("Invalid Number!");
                    break;
            }
        }
    }
}
