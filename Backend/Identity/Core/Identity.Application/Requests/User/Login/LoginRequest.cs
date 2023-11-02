using Identity.Application.Common.Errors.Requests;
using Identity.Application.Common.Models.Response;
using Identity.Domain.Types;
using MediatR;

namespace Identity.Application.Requests.User.Login;

public class LoginRequest : IRequest<Result<LoginTokensResponse, LoginError>>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}