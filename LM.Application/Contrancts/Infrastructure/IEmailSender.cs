using LM.Application.Models;

namespace LM.Application.Contrancts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
