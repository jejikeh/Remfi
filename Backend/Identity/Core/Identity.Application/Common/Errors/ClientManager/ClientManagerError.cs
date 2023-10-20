using Identity.Domain.Types;

namespace Identity.Application.Common.Errors.ClientManager;

public class ClientManagerError : Error
{
    protected ClientManagerError(
        string message, 
        Type? causer = null,
        TraceLevel traceLevel = TraceLevel.Internal | TraceLevel.Error | TraceLevel.Important) 
        : base(message, 401, causer, traceLevel , null)
    {
    }

    protected ClientManagerError(
        string message, 
        Error[] errors, 
        Type? causer = null,
        TraceLevel traceLevel = TraceLevel.Internal | TraceLevel.Error | TraceLevel.Important) 
        : base(message, 401, causer, traceLevel , null)
    {
    }
}