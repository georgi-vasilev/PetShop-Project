using System.Collections.Generic;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    /// <summary>
    /// Class which is used as controller for cage table.
    /// </summary>
    public class CageController
    {
        private PetShopContext petShopContext;

        /// <summary>
        /// Empty constructor of this class which create new PetShopContext.
        /// </summary>
        public CageController()
        {
            this.petShopContext = new PetShopContext();
        }

        public CageController(PetShopContext context)
        {
            this.petShopContext = context;
        }


        /// <summary>
        /// Function that adds information about the cages in the database.
        /// </summary>
        /// <param name="cage">Argumet based on model used to add information in the database.</param>
        public void AddCage(Models.Cage cage)
        {
            using (petShopContext)
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
            using (petShopContext)
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
            using (petShopContext)
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
            using (petShopContext)
            {
                return petShopContext.Cages.ToList();
            }
        }
    }
}
