using Identity.Domain.Types;

namespace Identity.Application.Common.Errors.Requests;

public class ConfirmEmailError : Error
{
    private ConfirmEmailError(
        string message,
        int code, 
        Type causer, 
        Error[] error,
        TraceLevel traceLevel = TraceLevelPresets.ImportantToClient, 
        Exception? alternativeException = null) : base(message, code, error, causer, traceLevel, alternativeException)
    {
    }

    private ConfirmEmailError(
        string message,
        int code, 
        Type causer, 
        TraceLevel traceLevel = TraceLevelPresets.ImportantToClient, 
        Exception? alternativeException = null) : base(message, code, causer, traceLevel, alternativeException)
    {
    }
    
    public static ConfirmEmailError CreateConfirmEmailError(Type causer, Error error, Exception? alternativeException = null) =>
        new ConfirmEmailError(
            "Error occurred while confirming email!",
            401,
            causer,
            new[] { error },
            TraceLevel.Critical | TraceLevelPresets.ImportantToClient,
            alternativeException
        );
}