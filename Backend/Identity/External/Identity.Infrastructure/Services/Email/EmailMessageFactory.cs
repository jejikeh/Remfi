using System.Text;
using Identity.Application.Common.Models.Email;
using Identity.Application.Services;
using Identity.Domain.Models;
using Identity.Infrastructure.Configuration;
using Microsoft.AspNetCore.WebUtilities;

namespace Identity.Infrastructure.Services.Email;

public class EmailMessageFactory : IEmailMessageFactory
{
    private readonly IClientManager _clientManager;
    private readonly string _host;

    public EmailMessageFactory(IClientManager clientManager, IApplicationConfiguration configuration)
    {
        _clientManager = clientManager;
        _host = configuration.ApplicationEnvironmentConfiguration.Host;
    }
    
    public async Task<ConfirmEmailMessage> CreateConfirmEmailMessage(Client client)
    {
        var token = await _clientManager.GenerateEmailConfirmationTokenAsync(client);
        var tokenBytes = Encoding.UTF8.GetBytes(token);
        var tokenEncoded = WebEncoders.Base64UrlEncode(tokenBytes);
        
        return new ConfirmEmailMessage(
            $"{_host}/api/user/confirm-email/{client.Id}/{tokenEncoded}",
            "Confirm your email",
            client.Email!, 
            client.UserName!);
    }
}