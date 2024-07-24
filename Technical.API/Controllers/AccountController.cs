using Microsoft.AspNetCore.Mvc;
using Technical.API.Models;
using Technical.API.Models.Identity.Request;
using Technical.API.Models.Identity.Response;
using Technical.API.Repository.Auth;

namespace Technical.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _response;
        public AccountController(IAuthService authService)
        {
            this._authService = authService;
            _response = new ResponseDto();
        }
        

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            var response = await _authService.Login(request);
            if (response == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or Password is incorrect";
                return Unauthorized(_response);

            }
            _response.Result = response;
            _response.Message = "Login is Succesfully";
            return Ok(_response);

        }
    }
}
