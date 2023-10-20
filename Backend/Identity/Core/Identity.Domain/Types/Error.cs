using System.Text.Json.Serialization;

namespace Identity.Domain.Types;

public class Error
{
    public string Message { get; }
    public int Code { get; }
    public string? CauserName { get; }
    
    [JsonIgnore]
    public Type? Causer { get; }
    
    [JsonIgnore]
    public virtual Exception AlternativeException { get; }
    
    [JsonIgnore]
    public TraceLevel TraceLevel { get; }
    
    public Error[]? IncludeErrors { get; private set; }
    
    protected Error(
        string message, 
        int code, 
        Type? causer = null, 
        TraceLevel traceLevel = 0, 
        Exception? alternativeException = null)
    {
        Message = message;
        Code = code;
        TraceLevel = traceLevel;
        Causer = causer;
        CauserName = causer?.FullName;

        AlternativeException = alternativeException ?? new Exception("This is an alternative exception!");
    }
    
    protected Error(
        string message,
        int code,
        Error[] includeErrors,
        Type? causer = null,
        TraceLevel traceLevel = 0, 
        Exception? alternativeException = null)
    {
        Message = message;
        Code = code;
        TraceLevel = traceLevel;
        Causer = causer;
        CauserName = causer?.FullName;

        AlternativeException = alternativeException ?? new Exception("This is an alternative exception!");
        IncludeErrors = includeErrors;
    }
    
    public void IncludeSomeErrors(params Error[] includeErrors)
    {
        IncludeErrors = includeErrors;
    }

    public override string ToString() => $"[{Code}] {Message}";
}