namespace BundledAsyncSite.Host.Bus.EventHandlers
{
    using System.Threading;
    using BundledAsyncSite.Host.Events;

    /// <summary>
    /// Sleeps for provided amount of time. 
    /// </summary>
    public class LongRunningTask : EventHandlerBase<PerformLongRunningTask>
    {
        public override void Handle(PerformLongRunningTask @event)
        {
            Thread.Sleep(@event.MillisecondsToRun);
        }
    }
}