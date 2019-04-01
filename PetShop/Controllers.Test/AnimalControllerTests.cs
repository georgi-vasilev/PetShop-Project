using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using PetShop.Data.Models;
using PetShop.Data;
using PetShop.Data.Controllers;
using System;

namespace Controllers.Test
{
    [TestFixture]
    public class AnimalControllerTests
    {
        
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
                Breed = "aaaa",
                Sex = "m",
                EntryDate = DateTime.Now
            };

            service.AddAnimal(animal);

            mockSet.Verify(m => m.Add(It.IsAny<Animal>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

    }
}
