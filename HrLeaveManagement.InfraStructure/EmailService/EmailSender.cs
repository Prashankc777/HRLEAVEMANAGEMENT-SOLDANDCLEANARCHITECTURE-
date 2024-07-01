using HRLeaveManagement.Application.Contracts.Email;
using HRLeaveManagement.Application.Models.EmailModels;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HrLeaveManagement.InfraStructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSetting _emailSetting { get; }

        public EmailSender(IOptions<EmailSetting> emailSettings)
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
                Name = _emailSetting.FromName
            };

            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);
            return response.IsSuccessStatusCode;
        }
    }
}
