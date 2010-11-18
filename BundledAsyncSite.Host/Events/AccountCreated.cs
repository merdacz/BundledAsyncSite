namespace BundledAsyncSite.Host.Events
{
    using System.Runtime.Serialization;

    [DataContract]
    public class AccountCreated : EventBase
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}