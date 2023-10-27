using Identity.Application.Common.Errors.Requests;
using Identity.Application.Common.Models.Response;
using Identity.Application.Common.Results;
using Identity.Application.Services;
using Identity.Domain.Types;
using MediatR;

namespace Identity.Application.Requests.User.ResendEmailConfirmToken;

public class ResendEmailConfirmTokenHandle : IRequestHandler<ResendEmailConfirmTokenRequest, Result<ConfirmEmailTokenResendMessage, ConfirmEmailTokenResendError>>
{
    private readonly IClientManager _clientManager;
    private readonly IEmailSenderService _emailSenderService;
    private readonly IEmailMessageFactory _emailMessageFactory;

    public ResendEmailConfirmTokenHandle(IClientManager clientManager, IEmailSenderService emailSenderService, IEmailMessageFactory emailMessageFactory)
    {
        _clientManager = clientManager;
        _emailSenderService = emailSenderService;
        _emailMessageFactory = emailMessageFactory;
    }

    public async Task<Result<ConfirmEmailTokenResendMessage, ConfirmEmailTokenResendError>> Handle(ResendEmailConfirmTokenRequest request,
        CancellationToken cancellationToken)
    {
        var resultUserById = await _clientManager.GetClientById(request.ClientId);
        if (resultUserById.IsFailure)
        {
            return ConfirmEmailTokenResendError.UserNotFound(GetType(), resultUserById.GetError()!);
        }

        if (resultUserById.GetResult()!.EmailConfirmed)
        {
            return ConfirmEmailTokenResendError.EmailAlreadyConfirmed(GetType());
        }

        await _emailSenderService.SendEmailAsync(
            await _emailMessageFactory.CreateConfirmEmailMessage(resultUserById.GetResult()!));

        return new ConfirmEmailTokenResendMessage();
    }
}