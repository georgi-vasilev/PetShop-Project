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
    public class ConsultationAnimalControllerTests
    {
        /*SPRAVKI\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\*/
        [Test]
        public void GetAllTheSameSpeciesWhichContainSameSpecie()
        {
            var data = new List<Animal>
            {
                new Animal { Specie = "dog" },
                new Animal { Specie = "cat" },
                new Animal { Specie = "parrrot" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Animal>>();
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Animals).Returns(mockSet.Object);

            var service = new AnimalController(mockContext.Object);
            var animalsFound = service.AllTheSameSpecies("dog");

            Assert.AreEqual(1, animalsFound.Count());
            Assert.AreEqual("dog", animalsFound[0].Specie);

        }
        [Test]
        public void GetAllTheSameSpeciesWhichNoContainSameSpecie()
        {
            var data = new List<Animal>
            {
                new Animal { Specie = "dog" },
                new Animal { Specie = "cat" },
                new Animal { Specie = "parrrot" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Animal>>();
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Animals).Returns(mockSet.Object);

            var service = new AnimalController(mockContext.Object);
            var animalsFound = service.AllTheSameSpecies("elephanttt");

            Assert.AreEqual(0, animalsFound.Count());
        }



        [Test]
        public void GetAllTheSameBreedsWhichContainSameBreed()
        {
            var data = new List<Animal>
            {
                new Animal{ Breed="aaa"},
                new Animal{ Breed="bbb"},
                new Animal{ Breed="ccc"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Animal>>();
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Animals).Returns(mockSet.Object);

            var service = new AnimalController(mockContext.Object);
            var animalsFind = service.AllTheSameBreed("aaa");

            Assert.AreEqual(1, animalsFind.Count());
            Assert.AreEqual("aaa", animalsFind[0].Breed);
        }

        [Test]
        public void GetAllTheSameBreedsWhichNoContainSameBreed()
        {
            var data = new List<Animal>
            {
                new Animal{ Breed="aaa"},
                new Animal{ Breed="bbb"},
                new Animal{ Breed="ccc"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Animal>>();
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Animals).Returns(mockSet.Object);

            var service = new AnimalController(mockContext.Object);
            var animalsFind = service.AllTheSameBreed("fghbj");

            Assert.AreEqual(0, animalsFind.Count());
        }



        [Test]
        public void GetAllTheSameSexsWhichContainSameSex()
        {
            var data = new List<Animal>
            {
                new Animal{ Sex="aaa"},
                new Animal{ Sex="bbb"},
                new Animal{ Sex="ccc"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Animal>>();
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Animals).Returns(mockSet.Object);

            var service = new AnimalController(mockContext.Object);
            var animalsFind = service.AllTheSameSex("aaa");

            Assert.AreEqual(1, animalsFind.Count());
            Assert.AreEqual("aaa", animalsFind[0].Sex);
        }

        [Test]
        public void GetAllTheSameSexsWhichNoContainSameSex()
        {
            var data = new List<Animal>
            {
                new Animal{ Sex="aaa"},
                new Animal{ Sex="bbb"},
                new Animal{ Sex="ccc"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Animal>>();
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Animals).Returns(mockSet.Object);

            var service = new AnimalController(mockContext.Object);
            var animalsFind = service.AllTheSameBreed("fghbj");

            Assert.AreEqual(0, animalsFind.Count());
        }



    }
}
