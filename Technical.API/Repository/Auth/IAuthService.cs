using Technical.API.Models.Dtos.Auth;

namespace Technical.API.Repository.Auth
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}
