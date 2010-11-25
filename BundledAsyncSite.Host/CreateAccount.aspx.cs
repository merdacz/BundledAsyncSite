namespace BundledAsyncSite.Host
{
    using System;
    using BundledAsyncSite.Host.Common;
    using BundledAsyncSite.Host.EventHandlingServiceProxy;

    /// <summary>
    /// Account registration.
    /// </summary>
    public partial class CreateAccount : BasePage
    {
        protected void OnRegisterClicked(object sender, EventArgs e)
        {
            if (!this.Page.IsValid)
            {
                return;
            }

            var @event = new AccountCreated
                             {
                                 Email = this.Email.Text, 
                                 UserName = this.UserName.Text
                             };
            
            this.EventHandlingService.Handle(@event);
            Response.Redirect("Default.aspx");
        }
    }
}