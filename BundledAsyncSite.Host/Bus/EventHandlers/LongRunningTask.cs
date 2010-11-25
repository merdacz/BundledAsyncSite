namespace BundledAsyncSite.Host.Bus.EventHandlers
{
    using System.Security.Permissions;
    using System.Threading;
    using BundledAsyncSite.Host.Events;

    /// <summary>
    /// Sleeps for provided amount of time. 
    /// </summary>
    /// <remarks>
    /// Only administrators can call it. 
    /// </remarks>
    public class LongRunningTask : EventHandlerBase<PerformLongRunningTask>
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public override void Handle(PerformLongRunningTask @event)
        {
            Thread.Sleep(@event.MillisecondsToRun);
        }
    }
}