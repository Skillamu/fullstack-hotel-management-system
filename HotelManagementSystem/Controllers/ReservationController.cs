using HotelManagementSystem.Core.Application.Dtos;
using HotelManagementSystem.Core.Application.Services;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreateReservation(ReservationDto request)
        {
            var reservationId = _reservationService.Create(request);

            return reservationId == null ? BadRequest() : CreatedAtAction("VerifyReservation", new { Id = reservationId }, null);
        }

        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult VerifyReservation(Guid id, [FromBody] string verificationCode)
        {
            var verificationSucceed = _reservationService.Verify(id, verificationCode);

            return !verificationSucceed ? BadRequest() : Ok();
        }
    }
}