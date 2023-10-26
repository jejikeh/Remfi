using Identity.Application.Common.Errors;
using Identity.Application.Common.Errors.ClientManager;
using Identity.Application.Common.Errors.Requests;
using Identity.Application.Common.Models;
using Identity.Application.Common.Models.Response;
using Identity.Application.Common.Results;
using Identity.Application.Services;
using Identity.Domain.Models;
using Identity.Domain.Types;
using MediatR;

namespace Identity.Application.Requests.User.Register;

public class RegisterHandle : IRequestHandler<RegisterRequest, Result<UserCreatedMessage, RegisterRequestError>>
{
    private readonly IClientManager _clientManager;
    private readonly IEmailSenderService _emailSenderService;
    private readonly IEmailMessageFactory _emailMessageFactory;

    public RegisterHandle(IClientManager clientManager, IEmailSenderService emailSenderService, IEmailMessageFactory emailMessageFactory)
    {
        _clientManager = clientManager;
        _emailSenderService = emailSenderService;
        _emailMessageFactory = emailMessageFactory;
    }

    public async Task<Result<UserCreatedMessage, RegisterRequestError>> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var response = await _clientManager.Register(
            new Client(request.Nickname, request.Email), 
            request.Password);
        
        if (response.IsFailure)
        {
            return RegisterRequestError.ClientManagerError(
                GetType(), 
                response.GetError() ?? 
                new RegisterClientClientManagerError(
                    GetType(),
                    "The operation was marked as failed but error was not provided!",
                    TraceLevelPresets.StrangeError));
        }
        
        await _emailSenderService.SendEmailAsync(
            await _emailMessageFactory.CreateConfirmEmailMessage(response.GetResult()!));
        
        return new UserCreatedMessage(new LoginTokensResponse(response.GetResult()!, "123", "123"));
    }
}