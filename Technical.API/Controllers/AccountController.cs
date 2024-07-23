using Microsoft.AspNetCore.Mvc;
using Technical.API.Models.Identity.Request;
using Technical.API.Models.Identity.Response;
using Technical.API.Repository.Auth;

namespace Technical.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            this._authService = authService;
        }
        

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            var response = await _authService.Login(request);
            if (response == null)
            {
                return Unauthorized();
            }
            return Ok(response);
        }
    }
}
