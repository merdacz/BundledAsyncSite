namespace BundledAsyncSite.Host
{
    using System;
    using System.Net;
    using BundledAsyncSite.Host.Bus;
    using BundledAsyncSite.Host.Bus.EventHandlers;
    using AccountCreated = BundledAsyncSite.Host.Events.AccountCreated;
    using PerformLongRunningTask = BundledAsyncSite.Host.Events.PerformLongRunningTask;

    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var resolver = EventHandlerResolver.Instance;
            resolver.Register<AccountCreated, SendEmailOnAccountCreated>();
            resolver.Register<PerformLongRunningTask, LongRunningTask>();
        }
    }
}