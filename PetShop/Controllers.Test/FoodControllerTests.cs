using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PetShop.Data;
using PetShop.Data.Controllers;
using PetShop.Data.Models;

namespace Controllers.Test
{
    [TestFixture]
    public class FoodControllerTests
    {
        [Test]
        public void AddFoodSavesAFoodViaContext()
        {
            var mockSet = new Mock<DbSet<Food>>();

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(m => m.Food).Returns(mockSet.Object);

            var service = new FoodController(mockContext.Object);

            Food food = new Food()
            {
                FoodType = "Fish Food",
                Brand = "Idk smth random",
                Quantity = 10
            };

            service.AddFood(food);

            mockSet.Verify(m => m.Add(It.IsAny<Food>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
