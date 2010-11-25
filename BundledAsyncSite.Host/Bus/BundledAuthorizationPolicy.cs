namespace BundledAsyncSite.Host.Bus
{
    using System;
    using System.IdentityModel.Claims;
    using System.IdentityModel.Policy;
    using System.Security.Principal;
    using System.ServiceModel;
    using BundledAsyncSite.Host.Security;

    public class BundledAuthorizationPolicy : IAuthorizationPolicy
    {
        private string id;

        public ClaimSet Issuer
        {
            get { return ClaimSet.System; }
        }

        public string Id
        {
            get
            {
                this.id = Guid.NewGuid().ToString();
                return this.id;
            }
        }

        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            var headers = OperationContext.Current.IncomingMessageHeaders;
            var foundHeadersCount = headers.FindHeader(SecurityToken.Key, SecurityToken.Namespace);
            if (foundHeadersCount == 1)
            {
                var principal = headers.GetHeader<BundledPrincipal>(SecurityToken.Key, SecurityToken.Namespace);
                if (principal == null)
                {
                    evaluationContext.Properties["Principal"] = new GenericPrincipal(new GenericIdentity(string.Empty), null);
                }
                else
                {
                    evaluationContext.Properties["Principal"] = principal;
                }
            }

            return true;
        }
    }
}