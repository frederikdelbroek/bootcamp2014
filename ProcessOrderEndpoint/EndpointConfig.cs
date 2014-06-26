using NServiceBus;

namespace ProcessOrderEndpoint
{
	public class EndpointConfig 
        : IConfigureThisEndpoint
        , AsA_Publisher
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
