using PetShop.Data.Controllers;
using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Data.Views
{
    /// <summary>
    /// This class gives us the option to sell something from our shop.
    /// </summary>
    public class SaleMenu
    {
        /// <summary>
        /// The method creates a sale using some IDs and saves the data when the animal is sold.
        /// </summary>
        public static void MakeSale()
        {
            var sale = new Sales();
            var saleController = new SalesController();
            Console.WriteLine("Enter EmployeeID:");
            sale.EmployeeId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter ClientID:");
            sale.ClientId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter AnimalID:");
            sale.AnimalId = int.Parse(Console.ReadLine());
            sale.SaleDate = DateTime.Now;
            Console.WriteLine("Please wait...");
            saleController.Sale(sale);
        }
    }
}
