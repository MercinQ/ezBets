using ezBet.WebAPI.Domain;
using ezBet.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace ezBet.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        private readonly EzBetDbContext _ezBetDbContext;
        public ResetPasswordController(EzBetDbContext ezBetDbContext)
        {
            _ezBetDbContext = ezBetDbContext;
        }
        [HttpPost]
        public void ResetPassword([FromBody]ResetPasswordDTO resetPasswordModel)
        {
            //TODO: hashing and save new password to DB
        }

    }
}