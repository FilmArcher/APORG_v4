using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APORG_v4.Model;
using APORG_v4.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace APORG_v4.Pages
{
    [Authorize(Roles = SD.CustomerEndUser)]
    public class EventDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EventDetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Event Event { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _db.Events.SingleOrDefaultAsync(c => c.id == id);

            if (Event == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}