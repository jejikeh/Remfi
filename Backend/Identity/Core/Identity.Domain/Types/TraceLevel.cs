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