using Identity.Domain.Models;
using Identity.Domain.Types;

namespace Identity.Application.Common.Results;

public class UserCreatedMessage : Success<Client>
{
    public UserCreatedMessage(Client client, TraceLevel traceLevel = TraceLevel.Info | TraceLevel.Success) : base(client, traceLevel)
    {
    }
}