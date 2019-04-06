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
            Console.Write(String.Format("||{0,2}|", "Id"));
            Console.Write(String.Format("{0,15}|", "Cage Type"));
            Console.Write(String.Format("{0,3}||", "Cap"));
            Console.WriteLine();
            Console.WriteLine(new String('-', 26));
            foreach (var c in cageController.GetAllCages())
            {
                Console.Write(String.Format("||{0,2}|", c.Id));
                Console.Write(String.Format("{0,15}|", c.CageType));
                Console.Write(String.Format("{0,3}||", c.Capacity));
                Console.WriteLine();
                Console.WriteLine(new String('-', 26));
            }
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
