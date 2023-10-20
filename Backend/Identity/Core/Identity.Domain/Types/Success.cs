namespace Identity.Domain.Types;

public class Success<TValue>
{
    public TValue Value { get; set; }
    public TraceLevel TraceLevel { get; set; }

    public Success(TValue value, TraceLevel traceLevel = 0)
    {
        Value = value;
    }
}