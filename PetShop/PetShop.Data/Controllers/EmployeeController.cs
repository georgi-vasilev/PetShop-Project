using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    /// <summary>
    /// Class which is used as controller for employee table.
    /// </summary>
    class EmployeeController
    {
        private PetShopContext petShopContext;

        /// <summary>
        /// Function to add information about employee in the database.
        /// </summary>
        /// <param name="employees">Argumet based on model used to add information in the database.</param>
        public void AddEmployee(Models.Employee employees)
        {
            using (petShopContext = new PetShopContext())
            {
                petShopContext.Employees.Add(employees);
                petShopContext.SaveChanges();
            }
        }

        /// <summary>
        /// Function to update information about employee in the database.
        /// </summary>
        /// <param name="employee">Argumet based on model used to update information in the database.</param>
        public void UpdateEmployee(Models.Employee employee)
        {
            using (petShopContext = new PetShopContext())
            {
                var update = petShopContext.Employees.Find(employee.Id);
                if (update != null)
                {
                    petShopContext.Entry(update).CurrentValues.SetValues(employee);
                    petShopContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Function to delete information about employee in the database.
        /// </summary>
        /// <param name="employee">Argumet based on model used to delete information in the database.</param>
        public void Remove(Models.Employee employee /*int id*/)
        {
            using (petShopContext = new PetShopContext())
            {
                var delEmployee = petShopContext.Employees.Find(employee.Id);
                if (delEmployee != null)
                {
                    petShopContext.Employees.Remove(delEmployee);
                    petShopContext.SaveChanges();
                }
            }
        }


        /// <summary>
        /// Function that returns all information about employees in the database.
        /// </summary>
        /// <returns>Returns all employees to list</returns>
        public List<Employee> GetAllEmployees()
        {
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Employees.ToList();
            }
        }

        /// <summary>
        /// Function that search for employees by the given employee name and SSN
        /// </summary>
        /// <param name="employeeName">Argument which reads the employee name from the console</param>
        /// <param name="sSN">Argument which reads the ssn of the employee from the console.</param>
        /// <returns>Returns all found information using LINQ and Lambda</returns>
        public List<Employee> SearchByTagsEmployee(string employeeName, string sSN)
        {
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Employees.Where(x => x.EmployeeName == employeeName && x.Ssn == sSN).ToList();
            }
        }

    }
}
