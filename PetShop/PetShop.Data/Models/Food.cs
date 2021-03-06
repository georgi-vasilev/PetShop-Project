﻿using System;
using System.Collections.Generic;

namespace PetShop.Data.Models
{
    public partial class Food
    {
        public Food()
        {
            Animals = new HashSet<Animal>();
        }

        public int Id { get; set; }
        public string FoodType { get; set; }
        public string Brand { get; set; }
        public decimal Quantity { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
