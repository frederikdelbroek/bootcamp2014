using System;
using System.IO;

namespace InvoiceService
{
    public class InvoiceService
        : IInvoiceService
    {
        public void ProcessOrder(InvoiceOrder invoiceOrder)
        {
            System.Threading.Thread.Sleep(Convert.ToInt32(invoiceOrder.Price));

            var filename = String.Format("{0} - {1} - {2}", GetType().Name, invoiceOrder.CustomerName, Guid.NewGuid());
            File.Create(Path.Combine(@"C:\Temp\OrderProcessing", filename));
        }
    }
}