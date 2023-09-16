namespace HotelManagementSystem.Core.Application.Interfaces
{
    public interface IVerificationService
    {
        void Send(string phoneNr);
        bool Verify(string phoneNr, string verificationCode);
    }
}
