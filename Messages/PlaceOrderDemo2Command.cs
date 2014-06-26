using System;
using System.Collections.Generic;
using NServiceBus;

namespace Messages
{
    public class PlaceOrderDemo2Command
        : ICommand
    {
        public IEnumerable<OrderLine> OrderLines { get; set; }
        public String CustomerName { get; set; }
        public String CustomerEmail { get; set; }

        public class OrderLine
        {
            public int Quantity { get; set; }
            public Product Product { get; set; }
        }

        public class Product
        {
            public String Code { get; set; }
            public String Description { get; set; }
            public Decimal Price { get; set; }
        }
    }
}
