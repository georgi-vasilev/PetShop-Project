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


        [Test]
        public void GetAllClients()
        {
            var data = new List<Client>
            {
                new Client { ClientName = "Semir Mohamedov", Ssn= "0163248934" },
                new Client { ClientName = "John Gustav", Ssn = "3496245814" },
                new Client { ClientName = "Daniel Bashev", Ssn = "6987412536" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.As<IQueryable<Client>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Client>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Client>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Client>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Clients).Returns(mockSet.Object);

            var service = new ClientController(mockContext.Object);
            var ClientsFound = service.GetAllClients();

            Assert.AreEqual(3, ClientsFound.Count());
            Assert.AreEqual("0163248934", ClientsFound[0].Ssn);
            Assert.AreEqual("3496245814", ClientsFound[1].Ssn);
            Assert.AreEqual("6987412536", ClientsFound[2].Ssn);
        }
    }
}
