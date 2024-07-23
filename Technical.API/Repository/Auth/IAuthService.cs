using Technical.API.Models.Identity.Request;
using Technical.API.Models.Identity.Response;

namespace Technical.API.Repository.Auth
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}
