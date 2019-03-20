using System;
using System.Collections.Generic;

namespace PetShop.Data.Models
{
    public partial class Cages
    {
        public Cages()
        {
            Animals = new HashSet<Animals>();
        }

        public int Id { get; set; }
        public string CageType { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<Animals> Animals { get; set; }
    }
}
