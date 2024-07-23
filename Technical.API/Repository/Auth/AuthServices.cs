using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Technical.API.Exceptions;
using Technical.API.Models;
using Technical.API.Models.Dtos.Auth;

namespace Technical.API.Repository.Auth
{
    public class AuthServices : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            
        }
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                throw new NotFoundException($"User with {request.Username} not found", request.Username);
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                throw new BadRequestException($"Credential for {request.Username} arent valid.");
            }

            //JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            var response = new LoginResponse
            {
                Id = user.Id,
                //Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };

            return response;
        }
    }
}
