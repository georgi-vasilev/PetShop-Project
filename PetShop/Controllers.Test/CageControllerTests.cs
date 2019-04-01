using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PetShop.Data;
using PetShop.Data.Models;
using PetShop.Data.Controllers;

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
    }
}
