namespace BundledAsyncSite.Host.Security
{
    using System.Runtime.Serialization;
    using System.Security.Principal;
    using BundledAsyncSite.Host.Helpers;

    /// <summary>
    /// Custom principal, which assumes that user is assigned given role R if only if its user name contains X.
    /// </summary>
    [DataContract]
    [KnownType(typeof(BundledIdentity))]
    public class BundledPrincipal : IPrincipal
    {
        public BundledPrincipal(BundledIdentity identity)
        {
            this.Identity = identity;
        }

        [DataMember]
        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            Assume.That(() => !string.IsNullOrEmpty(role));
            var normalizedName = this.Identity.Name.ToUpper();
            var normalizedRole = role.ToUpper();
            return normalizedName.Contains(normalizedRole);
        }
    }
}