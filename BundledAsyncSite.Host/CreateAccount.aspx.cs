namespace BundledAsyncSite.Host
{
    using System;
    using BundledAsyncSite.Host.EventHandlingServiceProxy;

    /// <summary>
    /// Account registration.
    /// </summary>
    public partial class CreateAccount : System.Web.UI.Page
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

            using (var proxy = new EventHandlingServiceClient())
            {
                proxy.Handle(@event);    
            }

            Response.Redirect("Default.aspx");
        }
    }
}