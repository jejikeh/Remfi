using Identity.Domain.Types;

namespace Identity.Application.Common.Errors.Requests;

public class LoginError : Error
{
    private LoginError(
        string message,
        int code, 
        Type causer, 
        Error[] error,
        TraceLevel traceLevel = TraceLevelPresets.ImportantToClient, 
        Exception? alternativeException = null) : base(message, code, error, causer, traceLevel, alternativeException)
    {
    }
    
    private LoginError(
        string message,
        int code,
        Type causer, 
        TraceLevel traceLevel = TraceLevelPresets.ImportantToClient, 
        Exception? alternativeException = null) : base(message, code, causer, traceLevel, alternativeException)
    {
    }
    
    public static LoginError InvalidCredentials(Type causer, Exception? alternativeException = null) =>
        new LoginError(
            "Invalid credentials!",
            401,
            causer,
            TraceLevel.Critical | TraceLevelPresets.ImportantToClient,
            alternativeException
        );
    
    public static LoginError EmailNotConfirmed(Type causer, Exception? alternativeException = null) =>
        new LoginError(
            "Email is not confirmed!",
            401,
            causer,
            TraceLevel.Critical | TraceLevelPresets.ImportantToClient,
            alternativeException
        );
}