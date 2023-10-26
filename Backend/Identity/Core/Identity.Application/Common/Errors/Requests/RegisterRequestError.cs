using Identity.Application.Common.Errors.ClientManager;
using Identity.Domain.Types;

namespace Identity.Application.Common.Errors.Requests;

public class RegisterRequestError : Error
{
    private RegisterRequestError(
        string message,
        int code, 
        Type causer, 
        TraceLevel traceLevel = TraceLevel.Debug, 
        Exception? alternativeException = null) : base(message, code, causer, traceLevel, alternativeException)
    {
    }
    
    public static RegisterRequestError UserCollisionError(Type causer, Exception? alternativeException = null) =>
        new RegisterRequestError("User with these credentials already created!", 401, causer, TraceLevel.Critical, alternativeException);
    
    public static RegisterRequestError WeakPasswordError(Type causer, Exception? alternativeException = null) =>
        new RegisterRequestError("Password too weak!", 401, causer, TraceLevel.Critical, alternativeException);

    public static RegisterRequestError ClientManagerError(Type causer, RegisterClientClientManagerError registerClientClientManagerError)
    {
        var registerRequestError =  new RegisterRequestError(
            "Error occurred while processing client registration request!", 
            401, 
            causer,
            TraceLevel.Error | TraceLevel.Important | TraceLevel.VisibleToClient);
        
        registerRequestError.IncludeSomeErrors(registerClientClientManagerError);
        
        return registerRequestError;
    }
}