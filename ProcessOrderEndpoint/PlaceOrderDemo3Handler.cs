using System;
using System.Linq;
using Messages;
using NServiceBus;
using StockService;

namespace ProcessOrderEndpoint
{
    public class PlaceOrderDemo3Handler
        : IHandleMessages<PlaceOrderDemo3Command>
    {
        private readonly IStockService stockService;
        private readonly IBus bus;

        protected PlaceOrderDemo3Handler(IStockService stockService, IBus bus)
        {
            this.stockService = stockService;
            this.bus = bus;
        }

        public PlaceOrderDemo3Handler(IBus bus)
            : this(new StockService.StockService(), bus)
        {

        }

        public void Handle(PlaceOrderDemo3Command message)
        {
            Console.WriteLine("Handling message from {0} - Demo 3", message.CustomerName);

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

            bus.Publish(new OrderPlacedDemo3Event
            {
                CustomerName = message.CustomerName,
                CustomerEmail = message.CustomerEmail,
                OrderLines = message.OrderLines.Select(ol => new OrderPlacedDemo3Event.OrderLine
                {
                    Quantity = ol.Quantity,
                    Product = new OrderPlacedDemo3Event.Product
                    {
                        Code = ol.Product.Code,
                        Description = ol.Product.Description,
                        Price = ol.Product.Price
                    }
                })
            });
        }
    }
}