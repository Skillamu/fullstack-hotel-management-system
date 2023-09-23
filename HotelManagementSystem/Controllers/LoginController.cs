using HotelManagementSystem.Core.Application.Dtos;
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
        public ActionResult<Guid> SendVerificationCode(LoginForGuestRequestDto loginRequestDto)
        {
            var guestId = _loginService.SendVerificationCode(loginRequestDto);

            return guestId == null ? BadRequest() : Ok(guestId);
        }

        [HttpPost("guests/{id}")]
        public ActionResult<string> VerifyVerificationCodeAndGenerateToken(Guid id, LoginVerifyForGuestRequestDto loginVerifyRequestDto)
        {
            var token = _loginService.VerifyVerificationCodeAndGenerateToken(id, loginVerifyRequestDto);

            if (token == null)
            {
                return BadRequest();
            }

            return Ok(token);
        }
    }
}