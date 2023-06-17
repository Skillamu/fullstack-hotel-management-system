using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private string _connStr;

        public ReservationController(string connStr)
        {
            _connStr = connStr;
        }
    }
}