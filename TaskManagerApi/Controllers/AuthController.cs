using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApi.Models;
using TaskManagerApi.Utils;

namespace TaskManagerApi.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserApp model)
        {
            if (model.UserName == "admin" && model.Password == "1234") // Demo for testing
            {
                string tokenString = JwtConfigurator.GenerateJwtToken(model, _config);
                return Ok(new { tokenString });
            }
            return Unauthorized();
        }
    }
}
