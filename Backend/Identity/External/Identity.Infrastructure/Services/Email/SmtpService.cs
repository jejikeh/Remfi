using Identity.Application.Services;
using Identity.Infrastructure.Common;
using Identity.Infrastructure.Configuration;
using MailKit.Net.Smtp;

namespace Identity.Infrastructure.Services.Email;

public class SmtpService : SmtpClient
{
    private readonly EmailSmtpConfiguration _emailSmtpConfiguration;

    public SmtpService(IApplicationConfiguration applicationConfiguration)
    {
        _emailSmtpConfiguration = applicationConfiguration.EmailSmtpConfiguration;
    }

    public void Connect()
    {
        Connect(
            _emailSmtpConfiguration.Host, 
            _emailSmtpConfiguration.Port, 
            true);
        
        AuthenticationMechanisms.Remove("XOAUTH2");
        
        Authenticate(
            _emailSmtpConfiguration.Username, 
            _emailSmtpConfiguration.Password);
    }
}