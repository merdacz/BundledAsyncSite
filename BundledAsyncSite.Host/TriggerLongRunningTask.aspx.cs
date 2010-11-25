namespace BundledAsyncSite.Host
{
    using System;
    using BundledAsyncSite.Host.Common;
    using BundledAsyncSite.Host.EventHandlingServiceProxy;

    /// <summary>
    /// Long running task.
    /// </summary>
    public partial class TriggerLongRunningTask : BasePage
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

            this.EventHandlingService.Handle(@event);
            Response.Redirect("Default.aspx");
        }
    }
}