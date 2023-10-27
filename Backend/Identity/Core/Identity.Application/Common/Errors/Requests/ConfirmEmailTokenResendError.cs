using Identity.Domain.Types;

namespace Identity.Application.Common.Errors.Requests;

public class ConfirmEmailTokenResendError : Error
{
    private ConfirmEmailTokenResendError(
        string message,
        int code, 
        Type causer, 
        Error[] error,
        TraceLevel traceLevel = TraceLevelPresets.ImportantToClient, 
        Exception? alternativeException = null) : base(message, code, error, causer, traceLevel, alternativeException)
    {
    }
    
    private ConfirmEmailTokenResendError(
        string message,
        int code, 
        Type causer, 
        TraceLevel traceLevel = TraceLevelPresets.ImportantToClient, 
        Exception? alternativeException = null) : base(message, code, causer, traceLevel, alternativeException)
    {
    }
    
    public static ConfirmEmailTokenResendError UserNotFound(Type causer, Error error, Exception? alternativeException = null) =>
        new ConfirmEmailTokenResendError(
            "User not found!",
            404,
            causer,
            new[] { error },
            TraceLevel.Critical | TraceLevelPresets.ImportantToClient,
            alternativeException
        );
    
    public static ConfirmEmailTokenResendError EmailAlreadyConfirmed(Type causer, Exception? alternativeException = null) =>
        new ConfirmEmailTokenResendError(
            "The email already confirmed!",
            404,
            causer,
            TraceLevel.Critical | TraceLevelPresets.ImportantToClient,
            alternativeException
        );
}