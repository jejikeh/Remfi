using Identity.Application.Common.Results;
using Identity.Domain.Models;

namespace Identity.Application.Common.Models;

public class ClientViewModel
{
    public Guid Id { get; set; }
    public string Nickname { get; set; }
    public string Email { get; set; }

    private ClientViewModel(Guid id, string nickname, string email)
    {
        Id = id;
        Nickname = nickname;
        Email = email;
    }

    public static ClientViewModel MapFromClient(Client client)
    {
        return new ClientViewModel(client.Id, client.UserName, client.Email);
    }
}