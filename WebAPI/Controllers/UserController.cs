using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    public class UserModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly EzBetDbContext _ezBetDbContext;

        public UserController(IUserService userService, EzBetDbContext ezBetDbContext)
        {
            _userService = userService;
            _ezBetDbContext = ezBetDbContext;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public string Authenticate([FromBody]UserModel user)
        {
            var token = _userService.GetToken(user.Login, user.Password);
            return token;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserModel user)
        {
            if (_userService.Register(user))
                return Ok();
            return BadRequest();

        }
    }
}
