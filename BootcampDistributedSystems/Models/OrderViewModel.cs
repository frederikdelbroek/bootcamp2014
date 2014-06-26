using System;
using System.Collections.Generic;

namespace BootcampDistributedSystems.Models
{
    public class OrderViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public class Product
        {
            public String Code { get; set; }
            public String Description { get; set; }
            public Decimal Price { get; set; }
        }

        public OrderViewModel()
        {
            Products = new[]
            {
                new Product {Code = "Product01", Description = "Super Laptop", Price = 1250m},
                new Product {Code = "Product02", Description = "Super Windows Phone", Price = 450m},
                new Product {Code = "Product03", Description = "Super Windows Tablet", Price = 950m}
            };
        }
    }
}