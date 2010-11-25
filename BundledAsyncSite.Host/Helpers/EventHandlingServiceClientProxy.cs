namespace BundledAsyncSite.Host.Helpers
{
    using System;
    using System.ServiceModel;
    using System.Web;
    using BundledAsyncSite.Host.EventHandlingServiceProxy;
    using BundledAsyncSite.Host.Security;

    /// <summary>
    /// Provides additional security context passing for <see cref="EventHandlingServiceClient"/>.
    /// </summary>
    /// <remarks>
    /// This class is not thread safe. 
    /// </remarks>
    public class EventHandlingServiceClientProxy : EventHandlingService, IDisposable
    {
        private EventHandlingServiceClient client;
        private bool disposed;

        public EventHandlingServiceClientProxy(EventHandlingServiceClient client)
        {
            this.client = client;
        }

        ~EventHandlingServiceClientProxy()
        {
            this.Dispose(false);
        }

        public void Handle(EventBase @event)
        {
            var channel = this.client.InnerChannel;
            using (new OperationContextScope(channel))
            {
                var principal = HttpContext.Current.User as BundledPrincipal;
                var header = new MessageHeader<BundledPrincipal>(principal);
                var untypedHeader = header.GetUntypedHeader(SecurityToken.Key, SecurityToken.Namespace);
                OperationContext.Current.OutgoingMessageHeaders.Add(untypedHeader);
                this.client.Handle(@event);
            }
        }

        void EventHandlingService.Handle(EventBase @event)
        {
            this.Handle(@event);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    var disposableComponent = (IDisposable)this.client;
                    disposableComponent.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}