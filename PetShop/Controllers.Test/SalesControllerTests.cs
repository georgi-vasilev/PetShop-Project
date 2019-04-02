using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PetShop.Data;
using PetShop.Data.Controllers;
using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        [Test]
        public void GetAllSales()
        {
            var data = new List<Sales>
            {
                new Sales { ClientId=2,EmployeeId=3,AnimalId=4, SaleDate=DateTime.Now },
                new Sales { ClientId=1,EmployeeId=7,AnimalId=5, SaleDate=DateTime.Now },
                new Sales { ClientId=4,EmployeeId=8,AnimalId=2, SaleDate=DateTime.Now },
            }.AsQueryable();


            var mockSet = new Mock<DbSet<Sales>>();
            mockSet.As<IQueryable<Sales>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Sales>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Sales>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Sales>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Sales).Returns(mockSet.Object);

            var service = new SalesController(mockContext.Object);
            var salesFound = service.GetAllSales();

            Assert.AreEqual(3, salesFound.Count());
            Assert.AreEqual(3, salesFound[0].EmployeeId);
            Assert.AreEqual(7, salesFound[1].EmployeeId);
            Assert.AreEqual(8, salesFound[2].EmployeeId);
        }

       /* [Test]
        public void GetAllSalesOnTheSameDate()
        {
            var data = new List<Sales>
            {
                new Sales { ClientId=2,EmployeeId=3,AnimalId=4, SaleDate= DateTime.Parse("2019-04-02") },
                new Sales { ClientId=1,EmployeeId=7,AnimalId=5, SaleDate= DateTime.Parse("2019-04-02") },
                new Sales { ClientId=4,EmployeeId=8,AnimalId=2, SaleDate= DateTime.Parse("2019-04-02") },
            }.AsQueryable();


            var mockSet = new Mock<DbSet<Sales>>();
            mockSet.As<IQueryable<Sales>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Sales>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Sales>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Sales>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Sales).Returns(mockSet.Object);

            var service = new SalesController(mockContext.Object);
            var salesFound = service.GetAllSales();

            Assert.AreEqual(3, salesFound.Count());
            Assert.AreEqual("2019-04-02 00:00:00".ToString(), salesFound[0].SaleDate);
            Assert.AreEqual("2019-04-02 00:00:00".ToString(), salesFound[1].SaleDate);
            Assert.AreEqual("2019-04-02 00:00:00".ToString(), salesFound[2].SaleDate);
        }*/
    }
}
