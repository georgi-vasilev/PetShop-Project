using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    /// <summary>
    /// Class which is used as controller for food table.
    /// </summary>
    class FoodController
    {
        private PetShopContext petShopContext;

        /// <summary>
        /// Empty constructor of this class which create new PetShopContext.
        /// </summary>
        public FoodController()
        {
            this.petShopContext = new PetShopContext();
        }

        public FoodController(PetShopContext context)
        {
            this.petShopContext = context;
        }



        /// <summary>
        /// Method to add food in the database
        /// </summary>
        /// <param name="food">Argument based on model used to add information in the database.</param>
        public void AddFood(Models.Food food)
        {
            using (petShopContext)
            {
                petShopContext.Food.Add(food);
                petShopContext.SaveChanges();
            }
        }

        /// <summary>
        /// Method to update information about food in the database
        /// </summary>
        /// <param name="food">Argumet based on model used to update information in the database.</param>
        public void UpdateFood(Models.Food food)
        {
            using (petShopContext)
            {
                var update = petShopContext.Food.Find(food.Id);
                if (update != null)
                {
                    petShopContext.Entry(update).CurrentValues.SetValues(food);
                    petShopContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Method to delete food from the database
        /// </summary>
        /// <param name="food">Argumet based on model used to remove information in the database.</param>
        public void RemoveFood(Models.Food food /*int id*/)
        {
            using (petShopContext)
            {
                var delFood = petShopContext.Food.Find(food.Id);
                if (delFood != null)
                {
                    petShopContext.Food.Remove(delFood);
                    petShopContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Method to search for certain type of food
        /// </summary>
        /// <param name="foodType">Argument that reads the food type from the console</param>
        /// <param name="brand">Argument that reads the food brand from the console</param>
        /// <returns>Returns all foods based on the given input using LINQ and Lambda</returns>
        public List<Food> SearchByTagsFood(string foodType, string brand)
        {
            using (petShopContext)
            {
                return petShopContext.Food.Where(x => x.FoodType == foodType && x.Brand == brand).ToList();
            }
        }

        /// <summary>
        /// Method to return all information about the food
        /// </summary>
        /// <returns>Returns all food information converted to list.</returns>
        public List<Food> GetAllFoods()
        {
            using (petShopContext)
            {
                return petShopContext.Food.ToList();
            }
        }

    }
}
