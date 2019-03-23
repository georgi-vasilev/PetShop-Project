using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    class CageController
    {
        private PetShopContext petShopContext;

        public void AddCage(Models.Cage cage)
        {
            using (petShopContext = new PetShopContext())
            {
                petShopContext.Cages.Add(cage);
                petShopContext.SaveChanges();
            }
        }

        public void UpdateCage(Models.Cage cage)
        {
            using (petShopContext = new PetShopContext())
            {
                var update = petShopContext.Cages.Find(cage.Id);
                if (update != null)
                {
                    petShopContext.Entry(update).CurrentValues.SetValues(cage);
                    petShopContext.SaveChanges();
                }
            }
        }

        public void RemoveCage(Models.Cage cage /*int id*/)
        {
            using (petShopContext = new PetShopContext())
            {
                var delCage = petShopContext.Cages.Find(cage.Id);
                if (delCage != null)
                {
                    petShopContext.Cages.Remove(delCage);
                    petShopContext.SaveChanges();
                }
            }
        }


        public List<Cage> GetAllCages()
        {
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Cages.ToList();
            }
        }
    }
}
