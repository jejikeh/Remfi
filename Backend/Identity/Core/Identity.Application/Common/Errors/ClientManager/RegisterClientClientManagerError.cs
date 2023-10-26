using Identity.Domain.Types;

namespace Identity.Application.Common.Errors.ClientManager;

public class RegisterClientClientManagerError : ClientManagerError
{
    public RegisterClientClientManagerError(Type causer, string managerError) : base(managerError, causer)
    {
    }
    
    public RegisterClientClientManagerError(Type causer, string managerError, TraceLevel traceLevel) 
        : base(managerError, causer, traceLevel)
    {
    }
}