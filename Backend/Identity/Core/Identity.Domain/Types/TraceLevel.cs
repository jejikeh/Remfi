namespace Identity.Domain.Types;

[Flags]
public enum TraceLevel
{
    Debug,
    Internal,
    Info,
    Warning,
    Critical,
    Success,
    NotImportant,
    Important,
    Fatal,
    Error,
    VisibleToClient,
}

public static class TraceLevelPresets
{
    public const TraceLevel ImportantToClient = TraceLevel.Important | TraceLevel.VisibleToClient;
    
    public const TraceLevel StrangeError = TraceLevel.Debug | TraceLevel.Error | TraceLevel.Important | TraceLevel.Internal;
}