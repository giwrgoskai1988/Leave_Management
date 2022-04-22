using LM.Application.Models.Identity;

namespace LM.Application.Contrancts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
