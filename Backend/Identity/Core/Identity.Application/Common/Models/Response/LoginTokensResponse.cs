using Identity.Domain.Models;

namespace Identity.Application.Common.Models.Response;

public class LoginTokensResponse
{
    public ClientViewModel Client { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }

    public LoginTokensResponse(Client client, string accessToken, string refreshToken)
    {
        Client = ClientViewModel.MapFromClient(client);
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
}