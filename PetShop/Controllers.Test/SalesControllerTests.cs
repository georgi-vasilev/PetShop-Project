using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PetShop.Data;
using PetShop.Data.Controllers;
using PetShop.Data.Models;
using System;

namespace Controllers.Test
{
    [TestFixture]
    public class SalesControllerTests
    {
        [Test]
        public void MakeSaleSavesASaleViaContext()
        {
            var mockSet = new Mock<DbSet<Sales>>();

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(m => m.Sales).Returns(mockSet.Object);

            var service = new SalesController(mockContext.Object);

            Sales sale = new Sales()
            {
                AnimalId = 3,
                EmployeeId = 3,
                ClientId = 4,
                SaleDate = DateTime.Now
                
            };

            service.Sale(sale);

            mockSet.Verify(m => m.Add(It.IsAny<Sales>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
