using Identity.Application.Common.Models.Email;
using Identity.Domain.Models;

namespace Identity.Application.Services;

public interface IEmailMessageFactory
{
    public Task<ConfirmEmailMessage> CreateConfirmEmailMessage(Client client);
}