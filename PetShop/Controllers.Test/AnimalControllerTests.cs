using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.EntityFrameworkCore;
using PetShop.Data.Models;
using PetShop.Data;
using PetShop.Data.Controllers;

namespace Controllers.Test
{
    [TestFixture]
    public class AnimalControllerTests
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
        }


        [Test]
        public void AddAnimalSavesAnAnimalViaContext()
        {
            var mockSet = new Mock<DbSet<Animal>>();

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(m => m.Animals).Returns(mockSet.Object);
            var service = new AnimalController(mockContext.Object);
            Animal animal = new Animal()
            {
                Specie = "dog",
                Breed = "aaaa"
              
            };

            service.AddAnimal(animal);

            mockSet.Verify(m => m.Add(It.IsAny<Animal>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void RemoveAnimalRemovesAnAnimalViaContext()
        {
            //var mockSet = new Mock<DbSet<Animal>>();

            //var mockContext = new Mock<PetShopContext>();
            //mockContext.Setup(m => m.Animals).Returns(mockSet.Object);
            //var service = new AnimalController(mockContext.Object);
            //Animal animal = new Animal()
            //{
            //    Specie = "dog",
            //    Breed = "aaaa"

            //};

            //service.RemoveAnimal(animal);

            //mockSet.Verify(m => m.Remove(It.IsAny<Animal>()), Times.Once());
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());

           /* var data = new List<Animal>
            {
                new Animal { Id=1, Specie="dog"   },
                new Animal { Id=2, Specie="aaa" },
                new Animal { Id=3, Specie="bbb" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Animal>>();
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(c => c.Animals).Returns(mockSet.Object);

            var service = new AnimalController(mockContext.Object);
            Animal animalForDelete = new Animal { Id = 1 };

            service.

            // Assert.AreEqual(2, mockSet.Object.Count());


            mockSet.Verify(m => m.Remove(It.IsAny<Animal>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());*/





        }

        [Test]
        public void UpdateAnimalUpdatesAnAnimalViaContext()
        {
            var mockSet = new Mock<DbSet<Animal>>();

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(m => m.Animals).Returns(mockSet.Object);
            var service = new AnimalController(mockContext.Object);
            Animal animal = new Animal()
            {

                Specie = "dok",
                Breed = "aaaa",
                Id=9
            };

            service.UpdateAnimal(animal);

            mockSet.Verify(m => m.Update(It.IsAny<Animal>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

    }
}
