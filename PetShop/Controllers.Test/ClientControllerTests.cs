using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using PetShop.Data.Models;
using PetShop.Data;
using PetShop.Data.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace Controllers.Test
{
    [TestFixture]
    public class ClientControllerTests
    {
        [Test]
        public void AddClientSavesAnClientViaContext()
        {
            var mockSet = new Mock<DbSet<Client>>();

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(m => m.Clients).Returns(mockSet.Object);

            var service = new ClientController(mockContext.Object);

            Client client = new Client()
            {
                ClientName = "Nakata Jones",
                ClientAddress = "3rd Avenue",
                Ssn = "0356248930",
            };

            service.AddClient(client);

            mockSet.Verify(m => m.Add(It.IsAny<Client>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void GetAllTheSameClientNameWhichContainSameClientName()
        {
            var data = new List<Client>
            {
                new Client { ClientName = "Jhony" },
                new Client { ClientName = "Ivo" },
                new Client { ClientName = "Meowww" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.As<IQueryable<Client>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Client>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Client>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Client>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Clients).Returns(mockSet.Object);

            var service = new ClientController(mockContext.Object);
            var clientNameFound = service.GetAllTheSameClientName("Jhony");

            Assert.AreEqual(1, clientNameFound.Count());
            Assert.AreEqual("Jhony", clientNameFound[0].ClientName);

        }


    }
}
