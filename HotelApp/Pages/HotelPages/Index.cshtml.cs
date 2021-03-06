using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Data;
using HotelApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelApp.Pages.HotelPages
{
    public class IndexModel : PageModel
    {
        private readonly HotelContext context; 

        public IndexModel(HotelContext db)
        {
            context = db;
        }
        public IEnumerable<Room> Rooms { get; set; }

        public async Task OnGet()
        {
            Rooms = await context.GetRooms();
            //return (OkResult)Rooms;
        }
    }
}
