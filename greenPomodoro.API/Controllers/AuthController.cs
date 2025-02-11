using greenPomodoro.Application.Contracts.Identity;
using greenPomodoro.Application.Models.Identity;
using greenPomodoro.Identity.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace greenPomodoro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            LoginResponse response = await _authService.Login(loginRequest);
            return Ok(response);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<bool>> Register(RegisterRequest registerModel)
        {
            bool result = await _authService.Register(registerModel);
            if(result == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
