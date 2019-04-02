using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PetShop.Data;
using PetShop.Data.Models;
using PetShop.Data.Controllers;
using System.Linq;
using System.Collections.Generic;

namespace Controllers.Test
{
    [TestFixture]
    public class CageControllerTests
    {
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
        [Test]
        public void GetAllCages()
        {
            var data = new List<Cage>
            {
                new Cage { CageType = "Dog cage" },
                new Cage { CageType = "Parrots cage" },
                new Cage { CageType = "Aquarium" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Cage>>();
            mockSet.As<IQueryable<Cage>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Cage>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Cage>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Cage>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Cages).Returns(mockSet.Object);

            var service = new CageController(mockContext.Object);
            var cagesFound = service.GetAllCages();

            Assert.AreEqual(3, cagesFound.Count());
            Assert.AreEqual("Dog cage", cagesFound[0].CageType);
            Assert.AreEqual("Parrots cage", cagesFound[1].CageType);
            Assert.AreEqual("Aquarium", cagesFound[2].CageType);
        }
    }
}
