using Identity.Application.Common.Models.Email;
using Identity.Application.Services;
using Identity.Infrastructure.Common;
using Identity.Infrastructure.Configuration;
using MimeKit;

namespace Identity.Infrastructure.Services.Email;

public class EmailSenderService : IEmailSenderService
{
    private readonly SmtpService _smtpService;
    private readonly EmailSmtpConfiguration _emailSmtpConfiguration;

    public EmailSenderService(SmtpService smtpService, IApplicationConfiguration applicationConfiguration)
    {
        _smtpService = smtpService;
        _emailSmtpConfiguration = applicationConfiguration.EmailSmtpConfiguration;
    }

    public Task SendEmailAsync(EmailMessage emailMessage)
    {
        if (!_smtpService.IsConnected)
        {
            _smtpService.Connect();
        }
        
        return _smtpService.SendAsync(CreateMimeMessage(emailMessage));
    }

    private MimeMessage CreateMimeMessage(EmailMessage emailMessage)
    {
        var mimeMessage = new MimeMessage();
        mimeMessage.From.Add(new MailboxAddress(
            _emailSmtpConfiguration.Username, 
            _emailSmtpConfiguration.From));
        
        mimeMessage.To.Add(MailboxAddress.Parse(emailMessage.Email));
        mimeMessage.Subject = emailMessage.Subject;
        mimeMessage.Body = new TextPart("html") { Text = emailMessage.GetHtmlMessage() };

        return mimeMessage;
    } 
}