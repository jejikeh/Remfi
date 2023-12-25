using Identity.Domain.Models;

namespace Identity.Application.Services;

public interface IAuthTokensService
{
    public string GenerateAccessToken(Client client, IEnumerable<string> roles);
    public string GenerateRefreshToken(Client client);
    public bool ValidateAccessToken(string token);
    public bool ValidateRefreshToken(string token);
}