using NServiceBus;

namespace InvoicingEndpoint
{
    public class EndpointConfig 
        : IConfigureThisEndpoint
        , AsA_Server
    {
        public EndpointConfig()
        {
            Configure.With()
                .DefaultBuilder()
                .UseTransport<Msmq>()
                .PurgeOnStartup(false)
                .UnicastBus()
                .DisableTimeoutManager();
        }
    }
}
