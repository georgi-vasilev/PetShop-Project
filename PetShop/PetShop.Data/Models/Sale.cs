using System;

namespace PetShop.Data.Models
{
    public partial class Sales
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public int AnimalId { get; set; }
        public DateTime? SaleDate { get; set; }

        public virtual Animal Animal { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
