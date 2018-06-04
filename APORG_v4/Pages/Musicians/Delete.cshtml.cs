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

namespace APORG_v4.Pages.Musicians
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
        public Musician Musician { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Musician = await _db.Musicians.SingleOrDefaultAsync(c => c.Id == id);

            if (Musician == null)
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
            Musician = await _db.Musicians.FindAsync(id);

            if (Musician != null)
            {
                var uploads = Path.Combine(webRootPath, "images");
                var extension = Musician.Image.Substring(Musician.Image.LastIndexOf("."), Musician.Image.Length - Musician.Image.LastIndexOf("."));

                var ImagePath = Path.Combine(uploads, Musician.Id + extension);
                if (System.IO.File.Exists(ImagePath))
                {
                    System.IO.File.Delete(ImagePath);
                }

                _db.Musicians.Remove(Musician);
                await _db.SaveChangesAsync();

            }

            Message = "Musician deleted successfully!";
            return RedirectToPage("MusicianList");

        }
    }
}