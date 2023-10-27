using Identity.Application.Common.Errors.Requests;
using Identity.Application.Common.Results;
using Identity.Domain.Types;
using MediatR;

namespace Identity.Application.Requests.User.ResendEmailConfirmToken;

public class ResendEmailConfirmTokenRequest : IRequest<Result<ConfirmEmailTokenResendMessage, ConfirmEmailTokenResendError>>
{
    public required Guid ClientId { get; set; }
}