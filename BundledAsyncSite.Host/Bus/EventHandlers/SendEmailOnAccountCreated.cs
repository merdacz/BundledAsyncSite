﻿namespace BundledAsyncSite.Host.Bus.EventHandlers
{
    using System.Net.Mail;
    using BundledAsyncSite.Host.Events;

    public class SendEmailOnAccountCreated : EventHandlerBase<AccountCreated>
    {
        public override void Handle(AccountCreated @event)
        {
            using (var client = new SmtpClient())
            {
                var from = new MailAddress("nobody@nowhere.com", "Nobody");
                var to = new MailAddress(@event.Email, @event.UserName);
                var message = new MailMessage(from, to);
                message.Subject = "Your account has been created.";
                message.Body = string.Format(
                    @"
Hello {0},
you have been registered into our system. 

Best regards,
The Team
",
                    @event.UserName);
                client.Send(message);
            }
        }
    }
}