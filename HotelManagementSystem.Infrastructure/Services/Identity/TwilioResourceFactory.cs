using Twilio;
using Twilio.Rest.Verify.V2.Service;

namespace HotelManagementSystem.Infrastructure.Services.Identity
{
    public class TwilioResourceFactory
    {
        private readonly string _verificationServiceSid;

        public TwilioResourceFactory(string accountSid, string authToken, string verificationServiceSid)
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
