using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private string _connStr;

        public RoomController(string connStr)
        {
            _connStr = connStr;
        }
    }
}