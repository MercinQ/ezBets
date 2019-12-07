using ezBet.WebAPI.Domain;
using ezBet.WebAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ezBet.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserModelDTO user)
        {
            var token = _userService.GetToken(user.Login, user.Password);

            if (token == "user doesn't exist")
            {
                return NotFound(token);
            }

            if (token == "Wrong password")
            {
                return Unauthorized(token);
            }

            return Ok(token);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody]UserModelDTO user)
        {
            if (_userService.Register(user))
            {
                return Ok();
            }

            return BadRequest();
        }

        [Authorize]
        [HttpGet("check_token")]
        public IActionResult CheckToken()
        {
            return Ok(true);
        }

    }
}