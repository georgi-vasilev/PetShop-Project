using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PetShop.Data;
using PetShop.Data.Controllers;
using PetShop.Data.Models;

namespace Controllers.Test
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        [Test]
        public void AddEmployeeSavesAnEmployeeViaContext()
        {
            var mockSet = new Mock<DbSet<Employee>>();

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(m => m.Employees).Returns(mockSet.Object);

            var service = new EmployeeController(mockContext.Object);

            Employee employee = new Employee()
            {
               EmployeeName = "Andrew Jones",
               Ssn = "0135249630",
               Salary = 22136,
               JobType = "Vet"
            };

            service.AddEmployee(employee);

            mockSet.Verify(m => m.Add(It.IsAny<Employee>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
