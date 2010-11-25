namespace BundledAsyncSite.Host.Security
{
    using System;
    using System.Security.Principal;

    public class BundledIdentity : IIdentity
    {
        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated
        {
            get { throw new NotImplementedException(); }
        }
    }
}