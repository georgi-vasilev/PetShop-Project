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
            foreach (var f in foodController.GetAllFoods())
            {
                Console.WriteLine(f.FoodType + "||" + f.Brand + "||" + f.Quantity );
            }
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
