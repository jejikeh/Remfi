using Identity.Application.Common.Errors.ClientManager;
using Identity.Application.Services;
using Identity.Domain.Models;
using Identity.Domain.Types;
using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.Persistence.Repositories;

public class ClientManager : IClientManager
{
    private readonly UserManager<Client> _userManager;

    public ClientManager(UserManager<Client> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<Client, RegisterClientError>> Register(Client client, string password)
    {
        var result = await _userManager.CreateAsync(client, password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(identityError => 
                (Error) new RegisterClientError(GetType(), identityError.Description, TraceLevelPresets.ImportantToClient));
            
            var registerClientError = new RegisterClientError(
                GetType(), "Error occurred while registering client!",
                TraceLevelPresets.ImportantToClient);
            
            registerClientError.IncludeSomeErrors(errors.ToArray());
            
            return Result<Client, RegisterClientError>.Failure(registerClientError);
        }
        
        return Result<Client, RegisterClientError>.Success(client);
    }

    public Task<bool> VerifyPassword(Client client, string password)
    {
        throw new NotImplementedException();
    }

    public Task<Client?> GetClientByEmail(string email)
    {
        throw new NotImplementedException();
    }
}