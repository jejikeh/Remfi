using Identity.Application.Common.Errors;
using Identity.Application.Common.Errors.Requests;
using Identity.Application.Common.Results;
using Identity.Domain.Types;
using MediatR;

namespace Identity.Application.Requests.User.Register;

public class RegisterRequest : IRequest<Result<UserCreatedMessage, RegisterRequestError>>
{
    public required string Nickname { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}