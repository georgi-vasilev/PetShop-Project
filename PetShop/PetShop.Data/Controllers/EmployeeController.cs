using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Data.Models;
using System.Linq;

namespace PetShop.Data.Controllers
{
    class EmployeeController
    {
        private PetShopContext petShopContext;
        public void AddEmployee(Models.Employee employees)
        {
            using (petShopContext = new PetShopContext())
            {
                petShopContext.Employees.Add(employees);
                petShopContext.SaveChanges();
            }
        }

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

        public List<Employee> GetAllEmployees()
        {
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Employees.ToList();
            }
        }

        public List<Employee> SearchByTagsEmployee(string employeeName, string sSN)
        {
            using (petShopContext = new PetShopContext())
            {
                return petShopContext.Employees.Where(x => x.EmployeeName == employeeName && x.Ssn == sSN).ToList();
            }
        }

    }
}
