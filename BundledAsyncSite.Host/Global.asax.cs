namespace BundledAsyncSite.Host
{
    using System;
    using System.Web;
    using BundledAsyncSite.Host.Bus;
    using BundledAsyncSite.Host.Bus.EventHandlers;
    using BundledAsyncSite.Host.Security;
    using AccountCreated = BundledAsyncSite.Host.Events.AccountCreated;
    using PerformLongRunningTask = BundledAsyncSite.Host.Events.PerformLongRunningTask;

    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs args)
        {
            var resolver = EventHandlerResolver.Instance;
            resolver.Register<AccountCreated, SendEmailOnAccountCreated>();
            resolver.Register<PerformLongRunningTask, LongRunningTask>();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs args)
        {
            if (HttpContext.Current.User != null)
            {
                string userName = HttpContext.Current.User.Identity.Name;
                var identity = new BundledIdentity(userName);
                var principal  = new BundledPrincipal(identity);
                HttpContext.Current.User = principal;
            }
        }
    }
}