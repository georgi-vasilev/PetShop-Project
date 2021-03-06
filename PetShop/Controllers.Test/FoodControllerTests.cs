﻿using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PetShop.Data;
using PetShop.Data.Controllers;
using PetShop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Controllers.Test
{
    /// <summary>
    /// Test class for food controller.
    /// </summary>
    [TestFixture]
    public class FoodControllerTests
    {
        /// <summary>
        /// Test for AddFood function which add information
        /// about food in the database.
        /// </summary>
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

        /// <summary>
        /// Test for the method GetAllFoods which return all foods in the
        /// database.
        /// </summary>
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
            mockSet.As<IQueryable<Food>>().Setup(m => m.Provider)
                .Returns(data.Provider);
            mockSet.As<IQueryable<Food>>().Setup(m => m.Expression)
                .Returns(data.Expression);
            mockSet.As<IQueryable<Food>>().Setup(m => m.ElementType)
                .Returns(data.ElementType);
            mockSet.As<IQueryable<Food>>().Setup(m => m.GetEnumerator())
                .Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Food).Returns(mockSet.Object);

            var service = new FoodController(mockContext.Object);
            var foodsFound = service.GetAllFoods();

            Assert.AreEqual(3, foodsFound.Count());
            Assert.AreEqual("Dog food", foodsFound[0].FoodType);
            Assert.AreEqual("Cat food", foodsFound[1].FoodType);
            Assert.AreEqual("Fish food", foodsFound[2].FoodType);
        }

        /// <summary>
        /// Test method for the function which return all foods with the same brand
        /// </summary>
        [Test]
        public void GetAllFoodsWithTheSameBrand()
        {
            var data = new List<Food>
            {
                new Food { FoodType = "Dog food", Brand = "Solid Gold" },
                new Food { FoodType = "Cat food", Brand = "Solid Gold" },
                new Food { FoodType = "Fish food", Brand = "Nutro" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Food>>();
            mockSet.As<IQueryable<Food>>().Setup(m => m.Provider)
                .Returns(data.Provider);
            mockSet.As<IQueryable<Food>>().Setup(m => m.Expression)
                .Returns(data.Expression);
            mockSet.As<IQueryable<Food>>().Setup(m => m.ElementType)
                .Returns(data.ElementType);
            mockSet.As<IQueryable<Food>>().Setup(m => m.GetEnumerator())
                .Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Food).Returns(mockSet.Object);

            var service = new FoodController(mockContext.Object);
            var foodsFound = service.GetAllFoods();

            Assert.AreEqual(3, foodsFound.Count());
            Assert.AreEqual("Solid Gold", foodsFound[0].Brand);
            Assert.AreEqual("Solid Gold", foodsFound[1].Brand);
            Assert.AreEqual("Nutro", foodsFound[2].Brand);
        }

        /// <summary>
        /// Test for the function which return all foods with the same quantity.
        /// </summary>
        [Test]
        public void GetAllFoodsWithTheSameQuantity()
        {
            var data = new List<Food>
            {
                new Food { FoodType = "Dog food", Quantity = 17 },
                new Food { FoodType = "Cat food", Quantity = 17 },
                new Food { FoodType = "Fish food", Quantity = 8  },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Food>>();
            mockSet.As<IQueryable<Food>>().Setup(m => m.Provider)
                .Returns(data.Provider);
            mockSet.As<IQueryable<Food>>().Setup(m => m.Expression)
                .Returns(data.Expression);
            mockSet.As<IQueryable<Food>>().Setup(m => m.ElementType)
                .Returns(data.ElementType);
            mockSet.As<IQueryable<Food>>().Setup(m => m.GetEnumerator())
                .Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Food).Returns(mockSet.Object);

            var service = new FoodController(mockContext.Object);
            var foodsFound = service.GetAllFoods();

            Assert.AreEqual(3, foodsFound.Count());
            Assert.AreEqual(17, foodsFound[0].Quantity);
            Assert.AreEqual(17, foodsFound[1].Quantity);
            Assert.AreEqual(8, foodsFound[2].Quantity);
        }
    }
}
