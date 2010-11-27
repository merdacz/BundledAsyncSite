namespace BundledAsyncSite.Host.Bus
{
    using System.Security;
    using System.ServiceModel;
    using System.Threading;
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
                try
                {
                    handler.HandleUntyped(@event);
                }
                catch (SecurityException exception)
                {
                    this.Log(
                        string.Format(
                            "Cannot run {0} in response to {1} in the context of {2} due to security reasons. ",
                            handler.GetType().Name,
                            @event.GetType().Name,
                            Thread.CurrentPrincipal.Identity.Name),
                        exception);
                }
            }
        }

        private void Log(string format, SecurityException exception)
        {
            //// TODO for now we are just ignoring this
        }
    }
}
