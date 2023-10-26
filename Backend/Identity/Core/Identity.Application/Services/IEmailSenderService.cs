using Identity.Application.Common.Models.Email;

namespace Identity.Application.Services;

public interface IEmailSenderService
{
    public Task SendEmailAsync(EmailMessage emailMessage);
}