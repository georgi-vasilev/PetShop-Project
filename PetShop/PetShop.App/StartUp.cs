using PetShop.Data;
using System;
using System.Linq;

namespace PetShop.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new PetShopContext())
            {
                var animal = context.Animals.FirstOrDefault();

                Console.WriteLine(animal.Specie);
                Console.WriteLine(animal.Food.FoodType);
            }
        }
    }
}
