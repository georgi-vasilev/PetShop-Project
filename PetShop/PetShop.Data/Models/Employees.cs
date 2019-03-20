using System;
using System.Collections.Generic;

namespace PetShop.Data.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Sales = new HashSet<Sales>();
        }

        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Ssn { get; set; }
        public decimal Salary { get; set; }
        public string JobType { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }
    }
}
