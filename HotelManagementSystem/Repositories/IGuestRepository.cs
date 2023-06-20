using HotelManagementSystem.Models.Dtos;

namespace HotelManagementSystem.Repositories
{
    public interface IGuestRepository
    {
        public void Insert(GuestDto guestDto);
    }
}
