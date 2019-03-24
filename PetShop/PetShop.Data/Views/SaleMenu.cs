using PetShop.Data.Controllers;
using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Data.Views
{
    public class SaleMenu
    {
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
            Console.WriteLine("Please wait...");
            saleController.Sale(sale);
        }
    }
}
