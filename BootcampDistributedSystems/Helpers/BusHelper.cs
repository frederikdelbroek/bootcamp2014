using NServiceBus;

namespace BootcampDistributedSystems.Helpers
{
    public static class BusHelper
    {
        private static IBus bus;

        private static IBus Bus
        {
            get
            {
                return bus ?? (bus = Configure.With()
                    .DefaultBuilder()
                    .UseTransport<Msmq>()
                    .UnicastBus()
                    .SendOnly());
            }
        }

        public static void Send(object message)
        {
            Bus.Send(message);
        }
    }
}