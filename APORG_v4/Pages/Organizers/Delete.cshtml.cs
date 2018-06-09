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

namespace APORG_v4.Pages.Organizers
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
        public Organizer Organizer { get; set; }

        [TempData]
        public string Message { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string webRootPath = _hostingEnvironment.WebRootPath;
            Organizer = await _db.Organizers.FindAsync(id);

            if (Organizer != null)
            {
                var uploads = Path.Combine(webRootPath, "images");
                var extension = Organizer.Image.Substring(Organizer.Image.LastIndexOf("."), Organizer.Image.Length - Organizer.Image.LastIndexOf("."));

                var ImagePath = Path.Combine(uploads, Organizer.Id + extension);
                if (System.IO.File.Exists(ImagePath))
                {
                    System.IO.File.Delete(ImagePath);
                }

                _db.Organizers.Remove(Organizer);
                await _db.SaveChangesAsync();

            }

            Message = "Organizer deleted successfully!";
            return RedirectToPage("OrganizerList");

        }
    }
}