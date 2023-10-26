using Identity.Application.Common.Models.Response;
using Identity.Domain.Types;

namespace Identity.Application.Common.Results;

public class EmailConfirmedMessage : Success<EmailConfirmedResponse>
{
    public EmailConfirmedMessage(TraceLevel traceLevel = TraceLevel.Success | TraceLevel.VisibleToClient) 
        : base(new EmailConfirmedResponse(), traceLevel)
    {
    }
}