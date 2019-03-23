using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    class AnimalsController
    {

        private PetShopContext petShopContext;

        public void AddAnimal(Models.Animal animal)
        {
            using (petShopContext = new PetShopContext())
            {
                petShopContext.Animals.Add(animal);
                petShopContext.SaveChanges();
            }
        }

        public void RemoveAnimal(Models.Animal animal /*int id*/)
        {
            using (petShopContext = new PetShopContext())
            {
                var delAnimal = petShopContext.Animals.Find(animal.Id);
                if (delAnimal != null)
                {
                    petShopContext.Animals.Remove(delAnimal);
                    petShopContext.SaveChanges();
                }
            }
        }

        public void UpdateAnimal(Models.Animal animal)
        {
            using (petShopContext = new PetShopContext())
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
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Animals.Where(x => x.Breed == breed && x.Specie == specie).ToList();

            }

        }

        public List<Animal> GetAllAnimals()
        {
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Animals.ToList();
            }
        }


    }
}
