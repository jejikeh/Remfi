using Identity.Application.Common.Errors.ClientManager;
using Identity.Application.Common.Errors.Requests;
using Identity.Domain;
using Identity.Domain.Models;
using Identity.Domain.Types;

namespace Identity.Application.Services;

public interface IClientManager
{
    public Task<Result<Client, RegisterClientClientManagerError>> Register(Client client, string password);
    public Task<bool> VerifyPassword(Client client, string password);
    public Task<Client?> GetClientByEmailAwait(string email);
    public Task<string> GenerateEmailConfirmationTokenAsync(Client client);
    public Task<Result<Client, GetClientByIdClientManagerError>> GetClientById(Guid id);
    public Task<Result<bool, ConfirmEmailClientManagerError>> ConfirmEmailAsync(Client client, string token);
}