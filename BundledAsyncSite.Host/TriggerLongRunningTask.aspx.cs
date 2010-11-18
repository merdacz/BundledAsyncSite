namespace BundledAsyncSite.Host
{
    using System;
    using BundledAsyncSite.Host.EventHandlingServiceProxy;

    /// <summary>
    /// Long running task.
    /// </summary>
    public partial class TriggerLongRunningTask : System.Web.UI.Page
    {
        protected void OnExecuteClicked(object sender, EventArgs e)
        {
            if (!this.Page.IsValid)
            {
                return;
            }

            var @event = new PerformLongRunningTask
                             {
                                 MillisecondsToRun = int.Parse(this.ExecutionTime.Text)
                             };

            using (var proxy = new EventHandlingServiceClient())
            {
                proxy.Handle(@event);
            }

            Response.Redirect("Default.aspx");
        }
    }
}