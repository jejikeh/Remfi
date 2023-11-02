using Identity.Application.Common.Errors.Requests;
using Identity.Application.Common.Models.Response;
using Identity.Application.Services;
using Identity.Domain.Types;
using MediatR;

namespace Identity.Application.Requests.User.Login;

public class LoginHandle : IRequestHandler<LoginRequest, Result<LoginTokensResponse, LoginError>>
{
    private readonly IClientManager _clientManager;

    public LoginHandle(IClientManager clientManager)
    {
        _clientManager = clientManager;
    }
    
    public async Task<Result<LoginTokensResponse, LoginError>> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var userByEmailAwait = await _clientManager.GetClientByEmailAwait(request.Email);
        if (userByEmailAwait is null)
        {
            return LoginError.InvalidCredentials(GetType());
        }

        if (!userByEmailAwait.EmailConfirmed)
        {
            return LoginError.EmailNotConfirmed(GetType());
        }

        if (!await _clientManager.VerifyPassword(userByEmailAwait, request.Password))
        {
            return LoginError.InvalidCredentials(GetType());
        }

        return Result<LoginTokensResponse, LoginError>.Success(
            new LoginTokensResponse(userByEmailAwait, "123", "123")
        );
    }
}