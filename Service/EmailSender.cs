using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Service
{
    public class EmailSender : IEmailSender
    {
        public EmailOptions Options { get; set; }

        public EmailSender(IOptions<EmailOptions> emailOptions)
        {
            Options = emailOptions.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            string sendGridKey = "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";
            return Execute(sendGridKey, subject, message, email);
        }

        private Task Execute(string sendGridKey, string subject, string message, string email)
        {
            sendGridKey = "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";
            var client = new SendGridClient(sendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("spicerestoraunt@gmail.com", "Spice Restaurant"),
                Subject = "Test",
                PlainTextContent = "Order success",
                HtmlContent = "<strong>Congratulation, we will remind you about update</strong>",
                ReplyTo = new EmailAddress(email)
            };
            msg.AddTo(new EmailAddress(email));
            try
            {
                return client.SendEmailAsync(msg);
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}