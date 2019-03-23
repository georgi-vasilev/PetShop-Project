using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    class SalesController
    {
        private PetShopContext petShopContext;
        public void Sale(Models.Sales sale)
        {
            using (petShopContext = new PetShopContext())
            {
                petShopContext.Sales.Add(sale);
                petShopContext.SaveChanges();
            }
        }
        public List<Sales> GetAllSales()
        {
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Sales.ToList();
            }
        }
    }
}
