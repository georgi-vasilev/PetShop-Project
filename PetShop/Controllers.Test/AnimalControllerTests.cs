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
        /*[Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            var answer = 9;
            Assert.That(answer, Is.EqualTo(9), "Some useful error message");
        }*/


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



            //////////////////////////////////////////////////////
            /*service.RemoveAnimal(animal);
            mockSet.Verify(m => m.Remove(It.IsAny<Animal>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());*/
            //////////////////////////////////////////////////////
        }





        [Test]
        public void RemoveAnimal_removes_an_animal_via_context()
        {
            var mockSet = new Mock<DbSet<Animal>>();

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(m => m.Animals).Returns(mockSet.Object);

            var service = new AnimalController(mockContext.Object);

            Animal animal = new Animal()
            {
                //Id = 92,
                Specie="dog",
                Breed="aaaa"
           };

            //service.AddAnimal(animal);

            service.RemoveAnimal(animal);
            mockSet.Verify(m => m.Remove(It.IsAny<Animal>()), Times.Once());
            
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }


        [Test]
        public void UpdataeAnimal_updates_an_animal_via_context()
        {
            var mockSet = new Mock<DbSet<Animal>>();

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(m => m.Animals).Returns(mockSet.Object);

            var service = new AnimalController(mockContext.Object);

            Animal animal = new Animal()
            {
                //Id = 92,
                Specie = "dog",
                Breed = "aaaa"
            };

            //service.AddAnimal(animal);

            service.UpdateAnimal(animal);
            mockSet.Verify(m => m.Update(animal.), Times.Once());

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }





        /*[Test]//ne bachka dge
        public void GetAllAnimal_get_an_animal_via_context()
        {
            var mockSet = new Mock<DbSet<Animal>>();

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(m => m.Animals).Returns(mockSet.Object);

            var service = new AnimalController(mockContext.Object);

            service.GetAllAnimals();

            mockSet.GetType();
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

            /*service.RemoveAnimal(animal);
            mockSet.Verify(m => m.Remove(It.IsAny<Animal>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());*//*
        }*/

    }
}
