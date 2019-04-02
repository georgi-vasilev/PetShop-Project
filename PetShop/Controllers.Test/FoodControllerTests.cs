using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PetShop.Data;
using PetShop.Data.Controllers;
using PetShop.Data.Models;
using System.Collections.Generic;
using System.Linq;

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
        [Test]
        public void GetAllFoods()
        {
            var data = new List<Food>
            {
                new Food { FoodType = "Dog food", Quantity = 7 },
                new Food { FoodType = "Cat food", Quantity = 17 },
                new Food { FoodType = "Fish food", Quantity = 11  },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Food>>();
            mockSet.As<IQueryable<Food>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Food>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Food>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Food>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Food).Returns(mockSet.Object);

            var service = new FoodController(mockContext.Object);
            var foodsFound = service.GetAllFoods();

            Assert.AreEqual(3, foodsFound.Count());
            Assert.AreEqual("Dog food", foodsFound[0].FoodType);
            Assert.AreEqual("Cat food", foodsFound[1].FoodType);
            Assert.AreEqual("Fish food", foodsFound[2].FoodType);
        }
    }
}
