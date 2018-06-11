using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using APORG_v4.Model;
using APORG_v4.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace APORG_v4.Pages.Events
{
    [Authorize(Roles = SD.CustomerEndUser)]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;

        public DeleteModel(ApplicationDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public Event Event { get; set; }

        [TempData]
        public string Message { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string webRootPath = _hostingEnvironment.WebRootPath;
            Event = await _db.Events.FindAsync(id);

            if (Event != null)
            {
                var uploads = Path.Combine(webRootPath, "images");
                var extension = Event.Image.Substring(Event.Image.LastIndexOf("."), Event.Image.Length - Event.Image.LastIndexOf("."));

                var ImagePath = Path.Combine(uploads, Event.id + extension);
                if (System.IO.File.Exists(ImagePath))
                {
                    System.IO.File.Delete(ImagePath);
                }

                _db.Events.Remove(Event);
                await _db.SaveChangesAsync();

            }

            Message = "Event deleted successfully!";
            return RedirectToPage("EventList");

        }
    }
}