using System;
using System.Collections.Generic;

namespace PetShop.Data.Models
{
    public partial class Animal
    {
        public Animal()
        {
            Sales = new HashSet<Sales>();
        }

        public int Id { get; set; }
        public string Specie { get; set; }
        public string Breed { get; set; }
        public string Sex { get; set; }
        public DateTime EntryDate { get; set; }
        public int FoodId { get; set; }
        public int CageId { get; set; }

        public virtual Cage Cage { get; set; }
        public virtual Food Food { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
    }
}