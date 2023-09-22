using HotelManagementSystem.Core.Application.Dtos;
using HotelManagementSystem.Core.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet("roomtypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<RoomTypeDto>> GetRoomTypes()
        {
            var roomTypesDto = _roomRepository.GetRoomTypes()
                .Select(x => new RoomTypeDto(x.Type, x.HasCityView, x.HasBathtub));

            return Ok(roomTypesDto);
        }
    }
}
