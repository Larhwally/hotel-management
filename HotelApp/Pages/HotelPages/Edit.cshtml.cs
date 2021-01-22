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
    public class EditModel : PageModel
    {
        private readonly HotelContext context;

        public EditModel(HotelContext db)
        {
            context = db;
        }
        [BindProperty]
        public Room room { get; set; }

        public async Task OnGet(int id)
        {
            //Dictionary<string, object> result = new Dictionary<string, object>();
            room = await context.GetRoomById(id);
            //Console.WriteLine(room);
            //return room;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //Dictionary<string, object> result = new Dictionary<string, object>();
                var roomById = await context.GetRoomById(room.itbId);

                roomById.roomNumber = room.roomNumber;
                roomById.roomStatus = room.roomStatus;
                await context.UpdateRoom(room);

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
