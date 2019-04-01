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
        public void AddAnimal_saves_an_animal_via_context()
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
        public void UpdateAnimal_saves_an_animal_via_context()
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
