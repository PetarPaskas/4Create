using _4Create.Issuer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _4Create.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] string username)
        {
            var token = _tokenService.GenerateToken(username);

            return Ok(new { Token = token });
        }

        [Authorize]
        [HttpGet]
        public IActionResult Logout()
        {
            return Ok("MJAU");
        }
    }
}
