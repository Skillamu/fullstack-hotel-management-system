using HotelManagementSystem.Core.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("guests")]
        public ActionResult<Guid> SendVerificationCode([FromBody] string phoneNr)
        {
            var guestId = _loginService.SendVerificationCode(phoneNr);

            return guestId == null ? BadRequest() : Ok(guestId);
        }

        [HttpPost("guests/{id}")]
        public ActionResult<string> VerifyVerificationCodeAndGenerateToken(Guid id, [FromBody] string verificationCode)
        {
            var token = _loginService.VerifyVerificationCodeAndGenerateToken(id, verificationCode);

            if (token == null)
            {
                return BadRequest();
            }

            return Ok(token);
        }
    }
}