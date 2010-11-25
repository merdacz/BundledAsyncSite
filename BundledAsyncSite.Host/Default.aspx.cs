namespace BundledAsyncSite.Host
{
    using System;
    using System.Web.Security;
    using BundledAsyncSite.Host.Common;

    /// <summary>
    /// Main menu.
    /// </summary>
    public partial class Default : BasePage
    {
        protected void Page_Load()
        {
            var userName = this.Context.User.Identity.Name;
            if (string.IsNullOrEmpty(userName))
            {
                userName = "noone";
                this.AuthenticationPane.SetActiveView(this.NotAuthenticated);
            }
            else
            {
                this.AuthenticationPane.SetActiveView(this.Authenticated);
            }

            this.LoggedInAs.Text = userName;
        }

        protected void OnAuthenticate(object sender, EventArgs args)
        {
            var userName = this.UserName.Text;
            FormsAuthentication.SetAuthCookie(userName, false);
            this.RedirectToSelf();
        }

        protected void OnSignOut(object sender, EventArgs args)
        {
            FormsAuthentication.SignOut();
            this.RedirectToSelf();
        }
    }
}