using PetShop.Data.Controllers;
using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Data.Views.SearchViews
{
    public class CageSearch
    {
        public static void Search()
        {
            Console.WriteLine("Cages:");
            var cageController = new CageController();
            foreach (var c in cageController.GetAllCages())
            {
                Console.WriteLine(c.CageType + " || " + c.Capacity);
            }
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
