using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    /// <summary>
    /// Class which is used as controller for sales table.
    /// </summary>
    class SalesController
    {
        private PetShopContext petShopContext;

        /// <summary>
        /// Create new query for sale.
        /// </summary>
        /// <param name="sale">Argumet based on model used to add information in the database.</param>
        public void Sale(Models.Sales sale)
        {
            using (petShopContext = new PetShopContext())
            {
                petShopContext.Sales.Add(sale);
                petShopContext.SaveChanges();
            }
        }

        /// <summary>
        /// Method to display all made sales.
        /// </summary>
        /// <returns>Convert all sales entries to list</returns>
        public List<Sales> GetAllSales()
        {
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Sales.ToList();
            }
        }
    }
}
