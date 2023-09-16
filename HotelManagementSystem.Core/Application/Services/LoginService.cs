using HotelManagementSystem.Core.Application.Interfaces;
using HotelManagementSystem.Core.Domain.Model;
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

        public Guest? SendVerificationCode(string phoneNr)
        {
            var guest = _guestRepository.GetGuestByPhoneNr(phoneNr);

            if (guest == null)
            {
                return null;
            }

            _verificationService.Send(phoneNr);

            return guest;
        }

        public string? VerifyVerificationCodeAndGenerateToken(Guid id, string verificationCode)
        {
            var guest = _guestRepository.GetById(id);

            if (guest == null)
            {
                return null;
            }

            var verificationSucceed = _verificationService.Verify(guest.PhoneNr, verificationCode);

            if (!verificationSucceed)
            {
                return null;
            }

            var token = _authTokenService.GenerateToken();

            return token;
        }
    }
}
