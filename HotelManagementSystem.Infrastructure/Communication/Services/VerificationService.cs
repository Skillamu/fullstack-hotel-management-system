using HotelManagementSystem.Core.Domain.Services;
using HotelManagementSystem.Infrastructure.Communication.Factories;

namespace HotelManagementSystem.Infrastructure.Communication.Verification
{
    public class VerificationService : IVerificationService
    {
        private readonly TwilioClientFactory _twilioClientFactory;

        public VerificationService(TwilioClientFactory twilioClientFactory)
        {
            _twilioClientFactory = twilioClientFactory;
        }

        public void Send(string phoneNr)
        {
            _twilioClientFactory.CreateVerificationResource(phoneNr);
        }

        public bool Verify(string phoneNr, string verificationCode)
        {
            var verificationCheck = _twilioClientFactory.CreateVerificationCheckResource(phoneNr, verificationCode);

            return verificationCheck.Status == "approved";
        }
    }
}
