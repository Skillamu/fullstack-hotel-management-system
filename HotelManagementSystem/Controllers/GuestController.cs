using HotelManagementSystem.Models.Dtos;
using HotelManagementSystem.Repositories;
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

        [HttpPost]
        public void CreateGuest(GuestDto guestDto)
        {
            _guestRepository.Insert(guestDto);
        }
    }
}