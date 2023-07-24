using HotelManagementSystem.Core.Application.Dtos;
using HotelManagementSystem.Core.Application.Services;
using HotelManagementSystem.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ReservationDto> Create(ReservationDto request)
        {
            var reservation = _reservationService.Create(request);

            return reservation == null ? BadRequest() : Ok(request);
        }
    }
}