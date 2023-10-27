using System.Text;
using Identity.Application.Requests.User.ConfirmEmail;
using Identity.Application.Requests.User.Register;
using Identity.Application.Requests.User.ResendEmailConfirmToken;
using Identity.Domain.Types;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace Identity.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.GetFilteredErrors(error => error.TraceLevel.HasFlag(TraceLevel.VisibleToClient)));
        }
        
        return Ok(result.GetResult());
    }
    
    [HttpGet("confirm-email/{clientId:guid}/{token}")]
    public async Task<IActionResult> ConfirmEmail(Guid clientId, string token, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new ConfirmEmailRequest()
        {
            ClientId = clientId,
            Token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token))
        }, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.GetFilteredErrors(error => error.TraceLevel.HasFlag(TraceLevel.VisibleToClient)));
        }
        
        return Ok(result.GetResult());
    }
    
    [HttpGet("resend-email-confirm-token/{clientId:guid}/")]
    public async Task<IActionResult> ResendEmailConfirmToken(Guid clientId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new ResendEmailConfirmTokenRequest()
        {
            ClientId = clientId
        }, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.GetFilteredErrors(error => error.TraceLevel.HasFlag(TraceLevel.VisibleToClient)));
        }
        
        return Ok(result.GetResult());
    }
}