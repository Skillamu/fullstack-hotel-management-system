using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private string _connStr;

        public GuestController(string connStr)
        {
            _connStr = connStr;
        }
    }
}