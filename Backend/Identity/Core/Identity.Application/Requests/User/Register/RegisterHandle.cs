using Identity.Application.Common.Errors;
using Identity.Application.Common.Errors.ClientManager;
using Identity.Application.Common.Results;
using Identity.Application.Services;
using Identity.Domain.Models;
using Identity.Domain.Types;
using MediatR;

namespace Identity.Application.Requests.User.Register;

public class RegisterHandle : IRequestHandler<RegisterRequest, Result<UserCreatedMessage, RegisterRequestError>>
{
    private readonly IClientManager _clientManager;

    public RegisterHandle(IClientManager clientManager)
    {
        _clientManager = clientManager;
    }

    public async Task<Result<UserCreatedMessage, RegisterRequestError>> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var response = await _clientManager.Register(
            new Client(request.Nickname, request.Email), 
            request.Password);
        
        if (!response.IsSuccess)
        {
            return RegisterRequestError.ClientManagerError(
                GetType(), 
                response.GetError() ?? 
                new RegisterClientError(
                    GetType(),
                    "The operation was marked as failed but error was not provided!",
                    TraceLevelPresets.StrangeError));
        }
        
        return new UserCreatedMessage(response.GetResult()!);
    }
}