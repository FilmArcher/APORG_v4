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
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;

        public EditModel(ApplicationDbContext db, IHostingEnvironment hostingEnvironment)
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
            if(id == null)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                return Page();

            }

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var OrganizerFromDb = _db.Organizers.Where(m => m.Id == Organizer.Id).FirstOrDefault();

            if (files[0] != null && files[0].Length >0)
            {
                var uploads = Path.Combine(webRootPath, "images");
                var extension = OrganizerFromDb.Image.Substring(OrganizerFromDb.Image.LastIndexOf("."), OrganizerFromDb.Image.Length - OrganizerFromDb.Image.LastIndexOf("."));

                if(System.IO.File.Exists(Path.Combine(uploads, Organizer.Id+extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, Organizer.Id + extension));
                }

                extension = files[0].FileName.Substring(files[0].FileName.LastIndexOf("."), files[0].FileName.Length - files[0].FileName.LastIndexOf("."));
                using (var fileStream = new FileStream(Path.Combine(uploads, Organizer.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                Organizer.Image = @"\images\" + Organizer.Id + extension;
            }


            if (Organizer.Image != null)
            {
                OrganizerFromDb.Image = Organizer.Image;
            }
            OrganizerFromDb.Name = Organizer.Name;
            OrganizerFromDb.Country = Organizer.Country;
            OrganizerFromDb.Region = Organizer.Region;
            OrganizerFromDb.Town = Organizer.Town;
            OrganizerFromDb.Description = Organizer.Description;
            OrganizerFromDb.Contact = Organizer.Contact;

            await _db.SaveChangesAsync();
            Message = "Organizer updated successfully!";
            return RedirectToPage("OrganizerList");

        }
    }
}