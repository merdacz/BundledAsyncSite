namespace BundledAsyncSite.Host.Common
{
    using System;
    using System.Web.UI;
    using BundledAsyncSite.Host.EventHandlingServiceProxy;
    using BundledAsyncSite.Host.Helpers;

    /// <summary>
    /// Generic base page for usage with all web pages in the system. 
    /// </summary>
    public class BasePage : Page
    {
        public BasePage()
        {
            this.Init += (sender, args) =>
                             {
                                 var client = new EventHandlingServiceClient();
                                 this.EventHandlingService = new EventHandlingServiceClientProxy(client);
                             };
            this.Unload += (sender, args) => ((IDisposable)this.EventHandlingService).Dispose();
        }

        /// <summary>
        /// Gets proxy for calling back-end event handling service.
        /// </summary>
        /// <remarks>
        /// Lifetime of this object is manage on <see cref="BasePage"/> level. Do not affect it from outside 
        /// this scope.
        /// </remarks>
        protected EventHandlingService EventHandlingService { get; private set; }

        protected void RedirectToSelf()
        {
            this.Response.Redirect(this.Request.Url.AbsoluteUri);
        }
    }
}