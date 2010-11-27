namespace BundledAsyncSite.Host
{
    using System;
    using System.Transactions;
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

            using (var transaction = new TransactionScope())
            {
                using (var proxy = new EventHandlingServiceClient())
                {
                    proxy.Handle(@event);
                }

                transaction.Complete();
            }

            Response.Redirect("Default.aspx");
        }
    }
}