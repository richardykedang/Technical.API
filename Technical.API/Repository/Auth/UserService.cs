using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Technical.API.Models;

namespace Technical.API.Repository.Auth
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        // this one to get user ID
        private readonly IHttpContextAccessor _ContextAccessor;
        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor ContextAccessor)
        {
            this._userManager = userManager;
            this._ContextAccessor = ContextAccessor;
        }

        public string UserId { get => _ContextAccessor.HttpContext?.User?.FindFirstValue("uid"); }
    }
}
