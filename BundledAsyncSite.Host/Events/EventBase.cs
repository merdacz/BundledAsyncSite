namespace BundledAsyncSite.Host.Events
{
    using System.Runtime.Serialization;

    [DataContract]
    [KnownType(typeof(AccountCreated))]
    [KnownType(typeof(PerformLongRunningTask))]
    public abstract class EventBase
    {
    }
}