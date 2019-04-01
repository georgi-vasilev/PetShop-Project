using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    /// <summary>
    /// Class which is used as controller for cage table.
    /// </summary>
    class CageController
    {
        private PetShopContext petShopContext;


        /// <summary>
        /// Function that adds information about the cages in the database.
        /// </summary>
        /// <param name="cage">Argumet based on model used to add information in the database.</param>
        public void AddCage(Models.Cage cage)
        {
            using (petShopContext = new PetShopContext())
            {
                petShopContext.Cages.Add(cage);
                petShopContext.SaveChanges();
            }
        }


        /// <summary>
        /// Function that updates the information about the cages in the database.
        /// </summary>
        /// <param name="cage">Argumet based on model used to update information in the database.</param>
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


        /// <summary>
        /// Function that delete cage in the database.
        /// </summary>
        /// <param name="cage">Argumet based on model used to delete information in the database.</param>
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

        /// <summary>
        /// Function that returns all information about the cages in the database.
        /// </summary>
        /// <returns>Returns all cages information converted in list using LINQ and Lambda</returns>
        public List<Cage> GetAllCages()
        {
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Cages.ToList();
            }
        }
    }
}
