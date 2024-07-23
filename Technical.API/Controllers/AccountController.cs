using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Technical.API.Data;
using Technical.API.Models.Dtos;
using Technical.API.Models.Dtos.Auth;
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
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
