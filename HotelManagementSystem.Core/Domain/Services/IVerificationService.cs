namespace HotelManagementSystem.Core.Domain.Services
{
    public interface IVerificationService
    {
        void Send(string phoneNr);
        bool Verify(string phoneNr, string verificationCode);
    }
}
