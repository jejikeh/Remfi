using Identity.Application.Common.Errors.ClientManager;
using Identity.Domain.Types;

namespace Identity.Application.Common.Errors.Requests;

public class RegisterError : Error
{
    private RegisterError(
        string message,
        int code, 
        Type causer, 
        TraceLevel traceLevel = TraceLevel.Debug, 
        Exception? alternativeException = null) : base(message, code, causer, traceLevel, alternativeException)
    {
    }
    
    public static RegisterError UserCollisionError(Type causer, Exception? alternativeException = null) =>
        new RegisterError("User with these credentials already created!", 401, causer, TraceLevel.Critical, alternativeException);
    
    public static RegisterError WeakPasswordError(Type causer, Exception? alternativeException = null) =>
        new RegisterError("Password too weak!", 401, causer, TraceLevel.Critical, alternativeException);

    public static RegisterError ClientManagerError(Type causer, RegisterClientClientManagerError registerClientClientManagerError)
    {
        var registerRequestError =  new RegisterError(
            "Error occurred while processing client registration request!", 
            401, 
            causer,
            TraceLevel.Error | TraceLevel.Important | TraceLevel.VisibleToClient);
        
        registerRequestError.IncludeSomeErrors(registerClientClientManagerError);
        
        return registerRequestError;
    }
}