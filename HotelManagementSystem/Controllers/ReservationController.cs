using HotelManagementSystem.Core.ApplicationServices;
using HotelManagementSystem.Presentation.Mappers;
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
        public ActionResult<ReservationViewModel> Create(ReservationViewModel reservationViewModel)
        {
            var reservation = reservationViewModel.ToDomain();
            var reservationCreated = _reservationService.Create(reservation);

            return reservationCreated == null ? BadRequest() : Ok(reservationViewModel);
        }
    }
}