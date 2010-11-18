namespace BundledAsyncSite.Host.Events
{
    using System.Runtime.Serialization;

    [DataContract]
    public class PerformLongRunningTask : EventBase
    {
        [DataMember]
        public int MillisecondsToRun { get; set; }
    }
}