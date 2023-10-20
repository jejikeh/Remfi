using Identity.Domain.Types;

namespace Identity.Application.Common.Errors.ClientManager;

public class RegisterClientError : ClientManagerError
{
    public RegisterClientError(Type causer, string managerError) : base(managerError, causer)
    {
    }
    
    public RegisterClientError(Type causer, string managerError, TraceLevel traceLevel) 
        : base(managerError, causer, traceLevel)
    {
    }
}