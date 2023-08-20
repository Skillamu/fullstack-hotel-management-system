using Twilio;
using Twilio.Rest.Verify.V2.Service;

namespace HotelManagementSystem.Infrastructure.Communication.Factories
{
    public class TwilioClientFactory
    {
        private readonly string _verificationServiceSid;

        public TwilioClientFactory(string accountSid, string authToken, string verificationServiceSid)
        {
            TwilioClient.Init(accountSid, authToken);

            _verificationServiceSid = verificationServiceSid;
        }

        public VerificationResource CreateVerificationResource(string phoneNr)
        {
            var verification = VerificationResource.Create(
                to: $"+47{phoneNr}",
                channel: "sms",
                pathServiceSid: _verificationServiceSid
                );

            return verification;
        }

        public VerificationCheckResource CreateVerificationCheckResource(string phoneNr, string verificationCode)
        {
            var verificationCheck = VerificationCheckResource.Create(
                to: $"+47{phoneNr}",
                code: $"{verificationCode}",
                pathServiceSid: _verificationServiceSid
                );

            return verificationCheck;
        }
    }
}
