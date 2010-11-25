namespace BundledAsyncSite.Host.Security
{
    using System;
    using System.Security.Principal;

    public class BundledPrincipal : IPrincipal
    {
        public  BundledPrincipal(BundledIdentity identity)
        {
            this.Identity = identity;
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public IIdentity Identity { get; private set; }
    }
}