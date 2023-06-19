using HotelManagementSystem.Models;

namespace HotelManagementSystem.Repository
{
    public interface IGuestRepository
    {
        public IEnumerable<Guest> GetAll();
    }
}
