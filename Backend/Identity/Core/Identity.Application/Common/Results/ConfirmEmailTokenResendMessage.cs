using Identity.Application.Common.Models.Response;
using Identity.Domain.Types;

namespace Identity.Application.Common.Results;

public class ConfirmEmailTokenResendMessage : Success<ConfirmEmailTokenResendResponse>
{
    public ConfirmEmailTokenResendMessage(TraceLevel traceLevel = TraceLevelPresets.ImportantToClient)
        : base(new ConfirmEmailTokenResendResponse(), traceLevel)
    {
    }
}