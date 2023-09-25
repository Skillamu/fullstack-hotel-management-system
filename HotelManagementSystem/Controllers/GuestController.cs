using HotelManagementSystem.Core.Application.Dtos;
using HotelManagementSystem.Core.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly AccessControlService _accessControlService;
        private readonly ReservationService _reservationService;

        public GuestController(AccessControlService accessControlService, ReservationService reservationService)
        {
            _accessControlService = accessControlService;
            _reservationService = reservationService;
        }

        [Authorize]
        [HttpGet("{guestId}/reservations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ReservationResponseDto> ShowReservations(Guid guestId)
        {
            var hasAccess = _accessControlService.HasAccessToResource(User.FindFirstValue("guest_id"), guestId);

            if (!hasAccess)
            {
                return Unauthorized();
            }

            var reservationsResponseDto = _reservationService.ShowReservations(guestId);

            return reservationsResponseDto == null ? BadRequest() : Ok(reservationsResponseDto);
        }

        [Authorize]
        [HttpDelete("{guestId}/reservations/{reservationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CancelReservation(Guid guestId, Guid reservationId)
        {
            var hasAccess = _accessControlService.HasAccessToResource(User.FindFirstValue("guest_id"), guestId, reservationId);

            if (!hasAccess)
            {
                return Unauthorized();
            }

            var cancellationSucceed = _reservationService.CancelReservation(reservationId);

            if (cancellationSucceed == null)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
