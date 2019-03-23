using System;
using System.Collections.Generic;

namespace PetShop.Data.Models
{
    public partial class Cage
    {
        public Cage()
        {
            Animals = new HashSet<Animal>();
        }

        public int Id { get; set; }
        public string CageType { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
