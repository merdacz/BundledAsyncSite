namespace BundledAsyncSite.Host.Bus.EventHandlers
{
    using BundledAsyncSite.Host.Events;

    public abstract class EventHandlerBaseUntyped
    {
        public abstract void HandleUntyped(EventBase @event);
    }
}