using PetShop.Data.Controllers;
using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Data.Views.SearchViews
{
    public class FoodSearch
    {
        public static void Search()
        {
            Console.WriteLine("Available food:");
            var foodController = new FoodController();
            Console.Write(String.Format("||{0,2}|", "Id"));
            Console.Write(String.Format("{0,20}|", "Food Type"));
            Console.Write(String.Format("{0,15}|", "Brand"));
            Console.Write(String.Format("{0,8}||", "Quantity"));
            Console.WriteLine();
            Console.WriteLine(new String('-', 52));
            foreach (var f in foodController.GetAllFoods())
            {
                Console.Write(String.Format("||{0,2}|", f.Id));
                Console.Write(String.Format("{0,20}|", f.FoodType));
                Console.Write(String.Format("{0,15}|", f.Brand));
                Console.Write(String.Format("{0,8}||", f.Quantity));
                Console.WriteLine();
                Console.WriteLine(new String('-', 52));
            }
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
