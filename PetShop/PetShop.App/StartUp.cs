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
                MainMenu.Start();
            }
        }
    }
}
