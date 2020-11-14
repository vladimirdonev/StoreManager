﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductImg { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
