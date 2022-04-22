using LM.Application.Models.Email;

namespace LM.Application.Contrancts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
