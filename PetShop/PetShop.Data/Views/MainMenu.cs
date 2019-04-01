using System;

namespace PetShop.Data.Views
{
    /// <summary>
    /// This class contains a few methods to make the console
    /// user friendly and display the main menu.
    /// </summary>
    public class MainMenu
    {
        /// <summary>
        /// Function using do-while loop, in order to give the user
        /// an option to choose what they want to do.
        /// </summary>
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

        /// <summary>
        /// Function to visualize the possible options in the console
        /// which user can use
        /// </summary>
        public static void DisplayMenu()
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("1:Add");
            Console.WriteLine("2:Sale");
            Console.WriteLine("3:Remove");
            Console.WriteLine("4:Search");
            Console.WriteLine("0:End");
        }

        /// <summary>
        /// Function to redirect the user using switch operator.
        /// </summary>
        /// <param name="menu">The argument "menu" reads the given number from the console which is used
        /// in the switch operator </param>
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
