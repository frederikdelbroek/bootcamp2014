using System.Linq;
using InvoiceService;
using MailService;
using StockService;

namespace BootcampDistributedSystems.Handlers.PlaceOrder
{
    public class PlaceOrderHandler
    {
        private readonly IStockService stockService;
        private readonly IInvoiceService invoiceService;
        private readonly IMailService mailService;

        public PlaceOrderHandler()
            : this(new StockService.StockService(), new InvoiceService.InvoiceService(), new MailService.MailService())
        {
            
        }

        protected PlaceOrderHandler(IStockService stockService, IInvoiceService invoiceService, IMailService mailService)
        {
            this.stockService = stockService;
            this.invoiceService = invoiceService;
            this.mailService = mailService;
        }

        public void Handle(PlaceOrderCommand command)
        {
            //Verify Command
            //Out of scope

            //verwerk order is stock
            stockService.ProcessOrder(new StockOrder
            {
                CustomerName = command.CustomerName,
                OrderLines = command.OrderLines.Select(ol => new OrderLine
                {
                    Quantity = ol.Quantity,
                    ProductCode = ol.Product.Code
                })
            });

            //stuur door naar de facturatie
            invoiceService.ProcessOrder(new InvoiceOrder
            {
                CustomerName = command.CustomerName,
                Price = command.OrderLines.Sum(ol => ol.Quantity * ol.Product.Price)
            });

            //verzend mail naar klant
            mailService.SendMail(command.CustomerEmail);
        }
    }
}