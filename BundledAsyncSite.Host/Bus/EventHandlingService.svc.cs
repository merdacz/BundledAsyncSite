namespace BundledAsyncSite.Host.Bus
{
    using System.ServiceModel;
    using BundledAsyncSite.Host.Events;

    [ServiceContract]
    public class EventHandlingService
    {
        private static EventHandlerResolver resolver = EventHandlerResolver.Instance;

        [OperationContract(IsOneWay = true)]
        public void Handle(EventBase @event)
        {
            var handlers = resolver.Resolve(@event.GetType());
            foreach (var handler in handlers)
            {
                handler.HandleUntyped(@event);
            }
        }
    }
}
