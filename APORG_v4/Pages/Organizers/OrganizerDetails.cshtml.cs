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
    public class OrganizerDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public OrganizerDetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Organizer Organizer { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Organizer = await _db.Organizers.SingleOrDefaultAsync(c => c.Id == id);

            if (Organizer == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}