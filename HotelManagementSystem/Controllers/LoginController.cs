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

        [HttpPost]
        public ActionResult SendVerificationCode(LoginRequestDto loginRequestDto)
        {
            var wasSent = _loginService.SendVerificationCode(loginRequestDto);

            return !wasSent ? BadRequest() : Ok();
        }

        [HttpPost("verify")]
        public ActionResult<string> VerifyVerificationCodeAndGenerateToken(LoginVerifyRequestDto loginVerifyRequestDto)
        {
            var token = _loginService.VerifyVerificationCodeAndGenerateToken(loginVerifyRequestDto);

            return token == null ? BadRequest() : Ok(token);
        }
    }
}