using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PetShop.Data;
using PetShop.Data.Controllers;
using PetShop.Data.Models;
using System.Collections.Generic;
using System.Linq;

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
        [Test]
        public void GetAllEmployees()
        {
            var data = new List<Employee>
            {
                new Employee { EmployeeName = "Semir Mohamedov", Salary=2020 },
                new Employee { EmployeeName = "John Gustav", Salary = 2913 },
                new Employee { EmployeeName = "Daniel Bashev", Salary =2351 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Employee>>();
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PetShopContext>();
            mockContext.Setup(s => s.Employees).Returns(mockSet.Object);

            var service = new EmployeeController(mockContext.Object);
            var EmployeesFound = service.GetAllEmployees();

            Assert.AreEqual(3, EmployeesFound.Count());
            Assert.AreEqual("Semir Mohamedov", EmployeesFound[0].EmployeeName);
            Assert.AreEqual("John Gustav", EmployeesFound[1].EmployeeName);
            Assert.AreEqual("Daniel Bashev", EmployeesFound[2].EmployeeName);
        }
    }
}
