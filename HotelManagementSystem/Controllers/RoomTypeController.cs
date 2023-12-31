﻿using HotelManagementSystem.Core.Application.Dtos;
using HotelManagementSystem.Core.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomTypeController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<RoomTypeResponseDto>> GetRoomTypes()
        {
            var roomTypesResponseDto = _roomRepository.GetRoomTypes()
                .Select(roomType => new RoomTypeResponseDto(roomType.Type, roomType.HasCityView, roomType.HasBathtub));

            return Ok(roomTypesResponseDto);
        }
    }
}
