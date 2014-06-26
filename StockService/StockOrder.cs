using System;
using System.Collections.Generic;

namespace StockService
{
    public class StockOrder
    {
        public String CustomerName { get; set; }
        public IEnumerable<OrderLine> OrderLines { get; set; }
    }
}