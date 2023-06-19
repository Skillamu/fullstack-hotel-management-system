using HotelManagementSystem.Models;
using HotelManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestRepository _guestRepository;

        public GuestController(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        [HttpGet]
        public IEnumerable<Guest> GetAllGuests()
        {
            return _guestRepository.GetAll();
        }
    }
}