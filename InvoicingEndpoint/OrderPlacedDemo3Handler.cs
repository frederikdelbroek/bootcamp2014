using System;
using System.Linq;
using InvoiceService;
using Messages;
using NServiceBus;

namespace InvoicingEndpoint
{
    public class OrderPlacedDemo3Handler
        : IHandleMessages<OrderPlacedDemo3Event>
    {
        private readonly IInvoiceService invoiceService;

        protected OrderPlacedDemo3Handler(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        public OrderPlacedDemo3Handler()
            : this(new InvoiceService.InvoiceService())
        {
            
        }

        public void Handle(OrderPlacedDemo3Event message)
        {
            Console.WriteLine("Handling OrderPlacedDemo3Event from {0} - Invoicing Endpoint", message.CustomerName);
            //stuur door naar de facturatie
            invoiceService.ProcessOrder(new InvoiceOrder
            {
                CustomerName = message.CustomerName,
                Price = message.OrderLines.Sum(ol => ol.Quantity * ol.Product.Price)
            });
        }
    }
}
