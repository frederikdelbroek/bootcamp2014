using System;
using System.IO;

namespace StockService
{
    public class StockService
        : IStockService
    {
        public void ProcessOrder(StockOrder stockOrder)
        {
            //Maakt niet uit, het is een langlopend proces
            foreach (var orderLine in stockOrder.OrderLines)
            {
                System.Threading.Thread.Sleep(orderLine.Quantity * 1000);
            }

            var filename = String.Format("{0} - {1} - {2}", GetType().Name, stockOrder.CustomerName, Guid.NewGuid());
            File.Create(Path.Combine(@"C:\Temp\OrderProcessing", filename));
        }
    }
}