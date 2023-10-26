using Identity.Application.Common.Models.Email;
using Identity.Application.Services;
using Identity.Domain.Models;
using Identity.Infrastructure.Configuration;

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
        
        return new ConfirmEmailMessage(
            $"{_host}/confirm-email/{client.Id}/{token}",
            "Confirm your email",
            client.Email!, 
            client.UserName!);
    }
}