using Identity.Domain.Models;

namespace Identity.Application.Common.Models.Email;

public class ConfirmEmailMessage : EmailMessage
{
    private readonly string _urlToken;
    
    public ConfirmEmailMessage(string urlToken, string subject, string email, string name) : base(subject, email, name)
    {
        _urlToken = urlToken;
    }
    
    public override string GetHtmlMessage()
    {
        return $"<h1>Confirm your email</h1>" + $"<a href=\"{_urlToken}\">Confirm your email</a>";
    }
}