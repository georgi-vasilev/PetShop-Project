using System;
using System.Collections.Generic;

namespace PetShop.Data.Models
{
    public partial class Client
    {
        public Client()
        {
            Sales = new HashSet<Sales>();
        }

        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientAddress { get; set; }
        public string Ssn { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }
    }
}
