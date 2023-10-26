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

    public async Task<Result<Client, RegisterClientClientManagerError>> Register(Client client, string password)
    {
        var result = await _userManager.CreateAsync(client, password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(identityError => 
                (Error) new RegisterClientClientManagerError(GetType(), identityError.Description, TraceLevelPresets.ImportantToClient));
            
            var registerClientError = new RegisterClientClientManagerError(
                GetType(), "Error occurred while registering client!",
                TraceLevelPresets.ImportantToClient);
            
            registerClientError.IncludeSomeErrors(errors.ToArray());
            
            return Result<Client, RegisterClientClientManagerError>.Failure(registerClientError);
        }
        
        return Result<Client, RegisterClientClientManagerError>.Success(client);
    }

    public Task<bool> VerifyPassword(Client client, string password)
    {
        throw new NotImplementedException();
    }

    public Task<Client?> GetClientByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<string> GenerateEmailConfirmationTokenAsync(Client client)
    {
        return _userManager.GenerateEmailConfirmationTokenAsync(client);
    }

    public async Task<Result<Client, GetClientByIdClientManagerError>> GetClientById(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
        {
            return Result<Client, GetClientByIdClientManagerError>.Failure(
                new GetClientByIdClientManagerError(GetType(), $"Client with ID=[{id}] not found!", TraceLevelPresets.ImportantToClient));
        }
        
        return Result<Client, GetClientByIdClientManagerError>.Success(user);
    }

    public async Task<Result<bool, ConfirmEmailClientManagerError>> ConfirmEmailAsync(Client client, string token)
    {
        var result = await _userManager.ConfirmEmailAsync(client, token);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(identityError => 
                (Error) new ConfirmEmailClientManagerError(GetType(), identityError.Description, TraceLevelPresets.ImportantToClient));
            
            var confirmEmailClientManagerError = new ConfirmEmailClientManagerError(
                GetType(), "Error occurred while validating user token!",
                TraceLevelPresets.ImportantToClient);
            
            confirmEmailClientManagerError.IncludeSomeErrors(errors.ToArray());
            
            return Result<bool, ConfirmEmailClientManagerError>.Failure(confirmEmailClientManagerError);
        }
        
        return Result<bool, ConfirmEmailClientManagerError>.Success(true);
    }
}