using Identity.Domain.Types;

namespace Identity.Application.Common.Errors.ClientManager;

public class GetClientByIdClientManagerError : ClientManagerError
{
    public GetClientByIdClientManagerError(Type causer, string managerError) : base(managerError, causer)
    {
    }

    public GetClientByIdClientManagerError(Type causer, string managerError, TraceLevel traceLevel) 
        : base(managerError, causer, traceLevel)
    {
    }
}