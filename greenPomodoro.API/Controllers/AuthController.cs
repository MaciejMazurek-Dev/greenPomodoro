using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace greenPomodoro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Login(string email, string password)
        {
            string result = "token";
            return Ok(result);
        }
    }
}
