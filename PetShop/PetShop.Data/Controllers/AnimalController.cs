using System.Collections.Generic;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    /// <summary>
    /// Class which is used as controller for animals table.
    /// </summary>
    public class AnimalController
    {

        private PetShopContext petShopContext;

        /// <summary>
        /// Empty constructor of this class which create new PetShopContext.
        /// </summary>
        public AnimalController()
        {
            this.petShopContext = new PetShopContext();
        }

        /// <summary>
        /// Constructor which takes as argument context
        /// </summary>
        /// <param name="context"></param>
        public AnimalController(PetShopContext context)
        {
            this.petShopContext = context;
        }

        /// <summary>
        /// Method to add animal in the database
        /// </summary>
        /// <param name="animal">Argumet based on model used to add information in the database.</param>
        public void AddAnimal(Models.Animal animal)
        {
            using (petShopContext)
            {
                petShopContext.Animals.Add(animal);
                petShopContext.SaveChanges();
            }
        }

        /// <summary>
        /// Method to remove animal from the database.
        /// </summary>
        /// <param name="animal">Argumet based on model used to remove information in the database.</param>
        public void RemoveAnimal(Models.Animal animal /*int id*/)
        {
            using (petShopContext)
            {
                Animal delAnimal = petShopContext.Animals.Find(animal.Id);
                if (delAnimal != null)
                {
                    petShopContext.Animals.Remove(delAnimal);
                    petShopContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Method to update information about the animal.
        /// </summary>
        /// <param name="animal"></param>
        public void UpdateAnimal(Models.Animal animal)
        {
            using (petShopContext)
            {
                var update = petShopContext.Animals.Find(animal.Id);
                if (update != null)
                {
                    petShopContext.Entry(update).CurrentValues.SetValues(animal);
                    petShopContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Method to search animal by specie and breed
        /// </summary>
        /// <param name="specie">Argument which is read from the console</param>
        /// <param name="breed">Argument which is read from the console</param>
        /// <returns>Returns the found animal using LINQ and Lambda</returns>
        public List<Animal> SearchByTagsAnimal(string specie, string breed)
        {
            using (petShopContext)
            {
                return petShopContext.Animals.Where(x => x.Breed == breed && x.Specie == specie).ToList();

            }

        }

        /// <summary>
        /// Display all animals in the database
        /// </summary>
        /// <returns>Converts all animal entries to list.</returns>
        public List<Animal> GetAllAnimals()
        {
            using (petShopContext)
            {
                return petShopContext.Animals.ToList();
            }
        }



        /*SPRAVKI \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\*/
        /// <summary>
        /// Method to show animals which have same specie
        /// </summary>
        /// <param name="specie">Argument which is read from the console</param>
        /// <returns>Found the same specie from animals</returns>
        public List<Animal> AllTheSameSpecies(string specie)
        {
            List<Animal> result = new List<Animal>();
            using (petShopContext)
            {
                result = petShopContext.Animals.Where(a => a.Specie == specie).ToList();
            }
            return result;
        }



        /// <summary>
        /// Method to show animals which have same breed
        /// </summary>
        /// <param name="breed">Argument which is read from the console</param>
        /// <returns>Found the same breed from animals</returns>
        public List<Animal> AllTheSameBreed(string breed)
        {
            List<Animal> result = new List<Animal>();
            using (petShopContext)
            {
                result = petShopContext.Animals.Where(a => a.Breed == breed).ToList();
            }
            return result;
        }



        /// <summary>
        /// Method to show animals which have same sex
        /// </summary>
        /// <param name="sex">Argument which is read from the console</param>
        /// <returns>Found the same sex from animals</returns>
        public List<Animal> AllTheSameSex(string sex)
        {
            List<Animal> result = new List<Animal>();
            using (petShopContext)
            {
                result = petShopContext.Animals.Where(a => a.Sex == sex).ToList();
            }
            return result;
        }


    }
}
