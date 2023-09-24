using HotelManagementSystem.Core.Application.Dtos;
using HotelManagementSystem.Core.Application.Interfaces;
using HotelManagementSystem.Core.Domain.Repositories;

namespace HotelManagementSystem.Core.Application.Services
{
    public class LoginService
    {
        private readonly IAuthTokenService _authTokenService;
        private readonly IVerificationService _verificationService;
        private readonly IGuestRepository _guestRepository;

        public LoginService(IAuthTokenService authTokenService, IVerificationService verificationService, IGuestRepository guestRepository)
        {
            _authTokenService = authTokenService;
            _verificationService = verificationService;
            _guestRepository = guestRepository;
        }

        public bool SendVerificationCode(LoginForGuestRequestDto loginRequestDto)
        {
            var guest = _guestRepository.GetGuestByPhoneNr(loginRequestDto.PhoneNr);

            if (guest == null)
            {
                return false;
            }

            _verificationService.Send(guest.PhoneNr);

            return true;
        }

        public string? VerifyVerificationCodeAndGenerateToken(LoginVerifyForGuestRequestDto loginVerifyRequestDto)
        {
            var guest = _guestRepository.GetGuestByPhoneNr(loginVerifyRequestDto.PhoneNr);

            if (guest == null)
            {
                return null;
            }

            var verificationSucceed = _verificationService.Verify(guest.PhoneNr, loginVerifyRequestDto.VerificationCode);

            if (!verificationSucceed)
            {
                return null;
            }

            var token = _authTokenService.GenerateToken(guest.Id);

            return token;
        }
    }
}
