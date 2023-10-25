using LeaveManagement.Application.Models;

namespace LeaveManagement.Application.Contracts.Infrastructure
{
    public interface IEmailSenderService
    {
        Task<bool> SendEmail(Email email);
    }
}
