namespace BundledAsyncSite.Host.Security
{
    using System.Runtime.Serialization;
    using System.Security.Principal;

    /// <summary>
    /// Custom identity to be used together with <see cref="BundledPrincipal"/>. 
    /// </summary>
    [DataContract]
    public class BundledIdentity : IIdentity
    {
        public BundledIdentity(string name)
        {
            this.Name = name;
        }

        [DataMember]
        public string Name { get; private set; }

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { return !string.IsNullOrEmpty(this.Name); }
        }
    }
}