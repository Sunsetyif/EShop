﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class Product : BaseEntity
    {
        public decimal Price { get; set; }
      //  public string ImageURL { get; set; }
        public virtual Category Category { get; set; }
    }
}
