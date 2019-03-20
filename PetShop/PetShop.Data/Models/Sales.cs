using System;
using System.Collections.Generic;

namespace PetShop.Data.Models
{
    public partial class Sales
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int AnimalId { get; set; }
        public DateTime? SaleDate { get; set; }

        public virtual Animals Animal { get; set; }
        public virtual Clients Client { get; set; }
        public virtual Employees Employee { get; set; }
    }
}
