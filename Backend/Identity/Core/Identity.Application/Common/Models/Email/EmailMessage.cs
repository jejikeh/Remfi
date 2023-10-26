namespace Identity.Application.Common.Models.Email;

public abstract class EmailMessage
{
    public string Subject { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }

    protected EmailMessage(string subject, string email, string name)
    {
        Subject = subject;
        Email = email;
        Name = name;
    }
    
    public abstract string GetHtmlMessage();
}