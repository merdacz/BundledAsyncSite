namespace BundledAsyncSite.Host.Bus.EventHandlers
{
    using BundledAsyncSite.Host.Events;
    using BundledAsyncSite.Host.Helpers;

    public abstract class EventHandlerBase<T> : EventHandlerBaseUntyped where T : EventBase 
    {
        public abstract void Handle(T @event);

        public override void HandleUntyped(EventBase @event)
        {
            Assume.That(() => @event is T);
            this.Handle((T)@event);
        }
    }
}