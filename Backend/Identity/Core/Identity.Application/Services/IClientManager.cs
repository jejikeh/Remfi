using Identity.Application.Common.Errors.ClientManager;
using Identity.Domain;
using Identity.Domain.Models;
using Identity.Domain.Types;

namespace Identity.Application.Services;

public interface IClientManager
{
    public Task<Result<Client, RegisterClientError>> Register(Client client, string password);
    public Task<bool> VerifyPassword(Client client, string password);
    public Task<Client?> GetClientByEmail(string email);
}