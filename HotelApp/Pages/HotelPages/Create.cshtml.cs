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
    public class CreateModel : PageModel
    {
        private readonly HotelContext context;

        public CreateModel(HotelContext db)
        {
            context = db;
        }

        [BindProperty]
        public Room room { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await context.PostRoom(room);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
