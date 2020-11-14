using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string ProductIma { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
