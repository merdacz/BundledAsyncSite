namespace BundledAsyncSite.Host.Bus
{
    using System.ServiceModel;
    using System.Transactions;
    using BundledAsyncSite.Host.Events;

    [ServiceContract]
    [ServiceBehavior(TransactionAutoCompleteOnSessionClose = false, TransactionIsolationLevel = IsolationLevel.Unspecified)]
    public class EventHandlingService
    {
        private static EventHandlerResolver resolver = EventHandlerResolver.Instance;

        [OperationContract(IsOneWay = true)]
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
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
