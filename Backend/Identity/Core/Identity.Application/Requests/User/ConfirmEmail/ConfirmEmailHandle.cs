using Identity.Application.Common.Errors.Requests;
using Identity.Application.Common.Results;
using Identity.Application.Services;
using Identity.Domain.Types;
using MediatR;

namespace Identity.Application.Requests.User.ConfirmEmail;

public class ConfirmEmailHandle : IRequestHandler<ConfirmEmailRequest, Result<EmailConfirmedMessage, ConfirmEmailError>>
{
    private readonly IClientManager _clientManager;

    public ConfirmEmailHandle(IClientManager clientManager)
    {
        _clientManager = clientManager;
    }

    public async Task<Result<EmailConfirmedMessage, ConfirmEmailError>> Handle(ConfirmEmailRequest request, CancellationToken cancellationToken)
    {
        var resultUserById = await _clientManager.GetClientById(request.ClientId);
        if (resultUserById.IsFailure)
        {
            return ConfirmEmailError.CreateConfirmEmailError(GetType(), resultUserById.GetError()!);
        }
        
        var resultConfirmEmail = await _clientManager.ConfirmEmailAsync(resultUserById.GetResult()!, request.Token);
        if (resultConfirmEmail.IsFailure)
        {
            return ConfirmEmailError.CreateConfirmEmailError(GetType(), resultConfirmEmail.GetError()!);
        }

        return Result<EmailConfirmedMessage, ConfirmEmailError>.Success(
            new EmailConfirmedMessage()
        );
    }
}