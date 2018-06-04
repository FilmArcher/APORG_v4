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

namespace APORG_v4.Pages.Object
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
        public Model.Object Object { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Object = await _db.Objects.SingleOrDefaultAsync(c => c.Id == id);

            if (Object == null)
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
            Object = await _db.Objects.FindAsync(id);

            if (Object != null)
            {
                var uploads = Path.Combine(webRootPath, "images");
                var extension = Object.Image.Substring(Object.Image.LastIndexOf("."), Object.Image.Length - Object.Image.LastIndexOf("."));

                var ImagePath = Path.Combine(uploads, Object.Id + extension);
                if (System.IO.File.Exists(ImagePath))
                {
                    System.IO.File.Delete(ImagePath);
                }

                _db.Objects.Remove(Object);
                await _db.SaveChangesAsync();

            }

            Message = "Object deleted successfully!";
            return RedirectToPage("ObjectList");

        }
    }
}