using GestionConge.Application.Contracts.Email;
using GestionConge.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionConge.Instrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSetting { get; }
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSetting = emailSettings.Value;
        }
        public async Task<bool> SendEmail(EmailMessage email)
        {
            var client = new SendGridClient(_emailSetting.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSetting.FromAddress,
                Name = _emailSetting.FromName,
            };
            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body,email.Body);
            var response = await client.SendEmailAsync(message);

            return response.IsSuccessStatusCode;
        }
    }
}
