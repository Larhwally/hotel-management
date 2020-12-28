using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly HotelContext context;

        public RoomController(HotelContext db)
        {
            context = db;
        }

        // GET: api/<controller>/
        public IActionResult Index()
        {
            var result = context.GetRooms();
            return Ok(result);
        }
    }
}
