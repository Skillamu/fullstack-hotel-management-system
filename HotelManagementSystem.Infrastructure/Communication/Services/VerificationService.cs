using HotelManagementSystem.Core.Domain.Services;
using HotelManagementSystem.Infrastructure.Communication.Factories;

namespace HotelManagementSystem.Infrastructure.Communication.Verification
{
    public class VerificationService : IVerificationService
    {
        private readonly TwilioResourceFactory _twilioResourceFactory;

        public VerificationService(TwilioResourceFactory twilioResourceFactory)
        {
            _twilioResourceFactory = twilioResourceFactory;
        }

        public void Send(string phoneNr)
        {
            _twilioResourceFactory.CreateVerificationResource(phoneNr);
        }

        public bool Verify(string phoneNr, string verificationCode)
        {
            var verificationCheck = _twilioResourceFactory.CreateVerificationCheckResource(phoneNr, verificationCode);

            return verificationCheck.Status == "approved";
        }
    }
}
