using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Data.Models;


namespace PetShop.Data.Controllers
{
    class PetsShopController
    {
        private PetShopContext petShopContext;

        /// <summary>
        /// Empty constructor of this class which create new PetShopContext.
        /// </summary>
        public PetsShopController()
        {
            this.petShopContext = new PetShopContext();
        }

        public PetsShopController(PetShopContext context)
        {
            this.petShopContext = context;
        }

        public void AddFood(Models.Food food)
        {
            using (petShopContext)
            {  
                petShopContext.Food.Add(food);
                petShopContext.SaveChanges();
            }
        }
    }
}
