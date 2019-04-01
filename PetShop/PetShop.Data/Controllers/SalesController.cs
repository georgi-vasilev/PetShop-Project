using System.Collections.Generic;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    /// <summary>
    /// Class which is used as controller for sales table.
    /// </summary>
    public class SalesController
    {
        private PetShopContext petShopContext;

        /// <summary>
        /// Empty constructor of this class which create new PetShopContext.
        /// </summary>
        public SalesController()
        {
            this.petShopContext = new PetShopContext();
        }

        public SalesController(PetShopContext context)
        {
            this.petShopContext = context;
        }



        /// <summary>
        /// Create new query for sale.
        /// </summary>
        /// <param name="sale">Argumet based on model used to add information in the database.</param>
        public void Sale(Models.Sales sale)
        {
            using (petShopContext)
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
            using (petShopContext)
            {
                return petShopContext.Sales.ToList();
            }
        }
    }
}
