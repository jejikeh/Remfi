using Microsoft.AspNetCore.Identity;

namespace Identity.Domain.Models;

public sealed class Client : IdentityUser<Guid>
{
    public Client(string userName, string email)
    {
        Id = Guid.NewGuid();
        
        UserName = userName;
        NormalizedUserName = userName.ToUpper();
        
        Email = email;
        NormalizedEmail = email.ToUpper();
    }
}