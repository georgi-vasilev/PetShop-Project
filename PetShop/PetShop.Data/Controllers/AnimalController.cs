using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    public class AnimalController
    {

        private PetShopContext petShopContext;

        public AnimalController()
        {
            this.petShopContext = new PetShopContext();
        }

        public AnimalController(PetShopContext context)
        {
            this.petShopContext = context;
        }

        public void AddAnimal(Models.Animal animal)
        {
            using (petShopContext)
            {
                petShopContext.Animals.Add(animal);
                petShopContext.SaveChanges();
            }
        }

        public void RemoveAnimal(/*Models.Animal animal */int id)
        {
            using (petShopContext)
            {
                var delAnimal = petShopContext.Animals.FirstOrDefault(x=>x.Id==id);
                if (delAnimal != null)
                {
                    petShopContext.Animals.Remove(delAnimal);
                    petShopContext.SaveChanges();
                }
            }
        }

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

        public List<Animal> SearchByTagsAnimal(string specie, string breed)
        {
            using (petShopContext)
            {
                return petShopContext.Animals.Where(x => x.Breed == breed && x.Specie == specie).ToList();

            }

        }

        public List<Animal> GetAllAnimals()
        {
            using (petShopContext)
            {
                return petShopContext.Animals.ToList();
            }
        }


    }
}
