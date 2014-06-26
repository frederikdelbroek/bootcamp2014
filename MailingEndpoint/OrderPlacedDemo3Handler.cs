using System;
using MailService;
using Messages;
using NServiceBus;

namespace MailingEndpoint
{
    public class OrderPlacedDemo3Handler
        : IHandleMessages<OrderPlacedDemo3Event>
    {
        private readonly IMailService mailService;

        protected OrderPlacedDemo3Handler(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public OrderPlacedDemo3Handler()
            : this(new MailService.MailService())
        {
            
        }

        public void Handle(OrderPlacedDemo3Event message)
        {
            Console.WriteLine("Handling OrderPlacedDemo3Event from {0} - Mailing Endpoint", message.CustomerName);

            //verzend mail naar klant
            mailService.SendMail(message.CustomerEmail);
        }
    }
}
