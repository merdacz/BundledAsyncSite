namespace BundledAsyncSite.Host
{
    using System;
    using System.Transactions;
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

            using (var transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
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