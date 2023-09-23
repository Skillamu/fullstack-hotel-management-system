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

        public Guid? SendVerificationCode(LoginForGuestRequestDto loginRequestDto)
        {
            var guest = _guestRepository.GetGuestByPhoneNr(loginRequestDto.PhoneNr);

            if (guest == null)
            {
                return null;
            }

            _verificationService.Send(guest.PhoneNr);

            return guest.Id;
        }

        public string? VerifyVerificationCodeAndGenerateToken(Guid id, LoginVerifyForGuestRequestDto loginVerifyRequestDto)
        {
            var guest = _guestRepository.GetById(id);

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
