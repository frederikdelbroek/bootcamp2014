using System;
using System.Linq;
using InvoiceService;
using MailService;
using Messages;
using NServiceBus;
using StockService;

namespace ProcessOrderEndpoint
{
    public class PlaceOrderDemo2Handler
        : IHandleMessages<PlaceOrderDemo2Command>
    {
        private readonly IStockService stockService;
        private readonly IInvoiceService invoiceService;
        private readonly IMailService mailService;

        protected PlaceOrderDemo2Handler(IStockService stockService, IInvoiceService invoiceService, IMailService mailService)
        {
            this.stockService = stockService;
            this.invoiceService = invoiceService;
            this.mailService = mailService;
        }

        public PlaceOrderDemo2Handler()
            : this(new StockService.StockService(), new InvoiceService.InvoiceService(), new MailService.MailService())
        {
            
        }

        public void Handle(PlaceOrderDemo2Command message)
        {
            Console.WriteLine("Handling message from {0} - Demo 2", message.CustomerName);

            //verwerk order is stock
            stockService.ProcessOrder(new StockOrder
            {
                CustomerName = message.CustomerName,
                OrderLines = message.OrderLines.Select(ol => new OrderLine
                {
                    Quantity = ol.Quantity,
                    ProductCode = ol.Product.Code
                })
            });

            //stuur door naar de facturatie
            invoiceService.ProcessOrder(new InvoiceOrder
            {
                CustomerName = message.CustomerName,
                Price = message.OrderLines.Sum(ol => ol.Quantity * ol.Product.Price)
            });

            //verzend mail naar klant
            mailService.SendMail(message.CustomerEmail);
        }
    }
}
