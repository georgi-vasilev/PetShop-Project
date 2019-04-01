using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using PetShop.Data.Models;
using PetShop.Data;
using PetShop.Data.Controllers;

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
    }
}
