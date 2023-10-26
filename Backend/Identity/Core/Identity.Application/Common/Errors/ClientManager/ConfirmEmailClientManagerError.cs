using Identity.Domain.Types;

namespace Identity.Application.Common.Errors.ClientManager;

public class ConfirmEmailClientManagerError : ClientManagerError
{
    public ConfirmEmailClientManagerError(Type causer, string managerError) : base(managerError, causer)
    {
    }

    public ConfirmEmailClientManagerError(Type causer, string managerError, TraceLevel traceLevel) 
        : base(managerError, causer, traceLevel)
    {
    }
}