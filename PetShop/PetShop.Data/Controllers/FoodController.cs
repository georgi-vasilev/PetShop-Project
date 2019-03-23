using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    class FoodController
    {
        private PetShopContext petShopContext;
        public void AddFood(Models.Food food)
        {
            using (petShopContext = new PetShopContext())
            {
                petShopContext.Food.Add(food);
                petShopContext.SaveChanges();
            }
        }

        public void UpdateFood(Models.Food food)
        {
            using (petShopContext = new PetShopContext())
            {
                var update = petShopContext.Food.Find(food.Id);
                if (update != null)
                {
                    petShopContext.Entry(update).CurrentValues.SetValues(food);
                    petShopContext.SaveChanges();
                }
            }
        }

        public void RemoveFood(Models.Food food /*int id*/)
        {
            using (petShopContext = new PetShopContext())
            {
                var delFood = petShopContext.Food.Find(food.Id);
                if (delFood != null)
                {
                    petShopContext.Food.Remove(delFood);
                    petShopContext.SaveChanges();
                }
            }
        }
        public List<Food> SearchByTagsFood(string foodType, string brand)
        {
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Food.Where(x => x.FoodType == foodType && x.Brand == brand).ToList();
            }
        }
        public List<Food> GetAllFoods()
        {
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Food.ToList();
            }
        }

    }
}
