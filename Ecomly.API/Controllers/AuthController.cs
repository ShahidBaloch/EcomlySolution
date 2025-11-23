using Ecomly.Core.DTOs;
using Ecomly.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecomly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest("Invalid registration data");
            }
            AuthenticationResponse? res = await _userService.Register(registerRequest);
            if(res == null || res.Success == false)
            {
                return BadRequest(res);
            }
            return Ok(res);
             
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginRequest(LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Invalid userlogin data");
            }
            AuthenticationResponse? res = await _userService.Login(loginRequest);
            if( res == null || res.Success == false)
            {
                return Unauthorized(res);
            }
            return Ok(res);

        }
    }
}
