using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PetShop.Data;
using PetShop.Data.Models;
using PetShop.Data.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace Controllers.Test
{
    /// <summary>
    /// Test class for cage controller.
    /// </summary>
    [TestFixture]
    public class CageControllerTests
    {
        /// <summary>
        /// Test method for adding cages to the database.
        /// </summary>
        [Test]
        public void AddCagesSavesACagesViaContext()
        {
            var mockSet = new Mock<DbSet<Cage>>();

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(m => m.Cages).Returns(mockSet.Object);

            var service = new CageController(mockContext.Object);

            Cage cages = new Cage()
            {
                CageType = "Aquarium",
                Capacity = 21
            };

            service.AddCage(cages);

            mockSet.Verify(m => m.Add(It.IsAny<Cage>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Test for the method which return all cages which are the same type
        /// </summary>
        [Test]
        public void GetAllCagesWhichAreTheSameType()
        {
            var data = new List<Cage>
            {
                new Cage { CageType = "dogCage" },
                new Cage { CageType = "catCage" },
                new Cage { CageType = "parrrotCage" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Cage>>();
            mockSet.As<IQueryable<Cage>>().Setup(m => m.Provider)
                .Returns(data.Provider);
            mockSet.As<IQueryable<Cage>>().Setup(m => m.Expression)
                .Returns(data.Expression);
            mockSet.As<IQueryable<Cage>>().Setup(m => m.ElementType)
                .Returns(data.ElementType);
            mockSet.As<IQueryable<Cage>>().Setup(m => m.GetEnumerator())
                .Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Cages).Returns(mockSet.Object);

            var service = new CageController(mockContext.Object);
            var cageFound = service.AllTheSameCageType("dogCage");

            Assert.AreEqual(1, cageFound.Count());
            Assert.AreEqual("dogCage", cageFound[0].CageType);

        }

        /// <summary>
        /// Test for the method which returns all cages with the same capacity
        /// </summary>
        [Test]
        public void GetAllTheSameCapacityWhichContainSameCapacity()
        {
            var data = new List<Cage>
            {
                new Cage { Capacity = 7 },
                new Cage { Capacity = 6 },
                new Cage { Capacity = 9 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Cage>>();
            mockSet.As<IQueryable<Cage>>().Setup(m => m.Provider)
                .Returns(data.Provider);
            mockSet.As<IQueryable<Cage>>().Setup(m => m.Expression)
                .Returns(data.Expression);
            mockSet.As<IQueryable<Cage>>().Setup(m => m.ElementType)
                .Returns(data.ElementType);
            mockSet.As<IQueryable<Cage>>().Setup(m => m.GetEnumerator())
                .Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Cages).Returns(mockSet.Object);

            var service = new CageController(mockContext.Object);
            var cageFound = service.AllTheSameCapacity(7);

            Assert.AreEqual(1, cageFound.Count());
            Assert.AreEqual(7, cageFound[0].Capacity);
        }
    }
}
