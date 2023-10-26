using Identity.Application.Common.Models;
using Identity.Application.Common.Models.Response;
using Identity.Domain.Models;
using Identity.Domain.Types;

namespace Identity.Application.Common.Results;

public class UserCreatedMessage : Success<LoginTokensResponse>
{
    public UserCreatedMessage(
        LoginTokensResponse client, 
        TraceLevel traceLevel = TraceLevel.Info | TraceLevel.Success) : base(client, traceLevel)
    {
    }
}