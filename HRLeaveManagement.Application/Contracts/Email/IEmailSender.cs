using HRLeaveManagement.Application.Models.EmailModels;

namespace HRLeaveManagement.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}