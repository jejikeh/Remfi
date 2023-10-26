using Identity.Application.Common.Errors.Requests;
using Identity.Application.Common.Results;
using Identity.Domain.Types;
using MediatR;

namespace Identity.Application.Requests.User.ConfirmEmail;

public class ConfirmEmailRequest : IRequest<Result<EmailConfirmedMessage, ConfirmEmailError>>
{
    public required Guid ClientId { get; set; }
    public required string Token { get; set; }
}