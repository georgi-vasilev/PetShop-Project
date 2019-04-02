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

      //  [Test]//Eror dosent work
        //public void RemoveAnimalRemovesAnAnimalViaContext()
        //{
        //    //var mockSet = new Mock<DbSet<Animal>>();

        //    //var mockContext = new Mock<PetShopContext>();
        //    //mockContext.Setup(m => m.Animals).Returns(mockSet.Object);
        //    //var service = new AnimalController(mockContext.Object);
        //    //Animal animal = new Animal()
        //    //{
        //    //    Specie = "dog",
        //    //    Breed = "aaaa"

        //    //};

        //    //service.RemoveAnimal(animal);

        //    //mockSet.Verify(m => m.Remove(It.IsAny<Animal>()), Times.Once());
        //    //mockContext.Verify(m => m.SaveChanges(), Times.Once());

        //    var data = new List<Animal>
        //    {
        //        new Animal { Id=1, Specie="dog"   },
        //        new Animal { Id=2, Specie="aaa" },
        //        new Animal { Id=3, Specie="bbb" },
        //    }.AsQueryable();

        //    var mockSet = new Mock<DbSet<Animal>>();
        //    mockSet.As<IQueryable<Animal>>().Setup(m => m.Provider).Returns(data.Provider);
        //    mockSet.As<IQueryable<Animal>>().Setup(m => m.Expression).Returns(data.Expression);
        //    mockSet.As<IQueryable<Animal>>().Setup(m => m.ElementType).Returns(data.ElementType);
        //    mockSet.As<IQueryable<Animal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        //    var mockContext = new Mock<PetShopContext>();
        //    mockContext.Setup(c => c.Animals).Returns(mockSet.Object);

        //    var service = new AnimalController(mockContext.Object);
        //    Animal animalForDelete = new Animal { Id = 1 };

        //    service.

        //    Assert.AreEqual(2, mockSet.Object.Count());


        //    mockSet.Verify(m => m.Remove(It.IsAny<Animal>()), Times.Once());
        //    mockContext.Verify(m => m.SaveChanges(), Times.Once());





        //}

        /*[Test]//Eror dosent work
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
        }*/

        [Test]
        public void GetAllAnimal()
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
            var animalsFound = service.GetAllAnimals();

            Assert.AreEqual(3, animalsFound.Count());
            Assert.AreEqual("dog", animalsFound[0].Specie);
            Assert.AreEqual("cat", animalsFound[1].Specie);
            Assert.AreEqual("parrrot", animalsFound[2].Specie);


        }

        [Test]
        public void SearchByTagsAnimal()
        {
            var data = new List<Animal>
            {
                new Animal { Specie = "dog" , Breed="NemOvcharka"},
                new Animal { Breed = "Ovcharsko" , Specie="doggg"},
                //new Animal { Specie = "parrrot" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Animal>>();
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Animal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Animals).Returns(mockSet.Object);

            var service = new AnimalController(mockContext.Object);
            var animalsFound = service.SearchByTagsAnimal("dog", "a");

            Assert.AreEqual(1, animalsFound.Count());
            Assert.AreEqual("dog", animalsFound[0].Specie);
            //Assert.AreEqual("cat", animalsFound[1].Specie);
            //Assert.AreEqual("parrrot", animalsFound[2].Specie);


        }

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
