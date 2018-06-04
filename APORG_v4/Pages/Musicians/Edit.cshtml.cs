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
        public Musician Musician { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if(id == null)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return RedirectToPage("MusicianList");

            }

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var MusicianFromDb = _db.Musicians.Where(m => m.Id == Musician.Id).FirstOrDefault();

            if (files[0] != null && files[0].Length >0)
            {
                var uploads = Path.Combine(webRootPath, "images");
                var extension = MusicianFromDb.Image.Substring(MusicianFromDb.Image.LastIndexOf("."), MusicianFromDb.Image.Length - MusicianFromDb.Image.LastIndexOf("."));

                if(System.IO.File.Exists(Path.Combine(uploads, Musician.Id+extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, Musician.Id + extension));
                }

                extension = files[0].FileName.Substring(files[0].FileName.LastIndexOf("."), files[0].FileName.Length - files[0].FileName.LastIndexOf("."));
                using (var fileStream = new FileStream(Path.Combine(uploads, Musician.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                Musician.Image = @"\images\" + Musician.Id + extension;
            }

            
            if (Musician.Image != null)
            {
                MusicianFromDb.Image = Musician.Image;
            }
            MusicianFromDb.Name = Musician.Name;
            MusicianFromDb.Genre = Musician.Genre;
            MusicianFromDb.Country = Musician.Country;
            MusicianFromDb.Region = Musician.Region;
            MusicianFromDb.Town = Musician.Town;
            MusicianFromDb.Description = Musician.Description;
            MusicianFromDb.Image = Musician.Image;
            MusicianFromDb.Biography = Musician.Biography;
            MusicianFromDb.First_name_manager = Musician.First_name_manager;
            MusicianFromDb.Last_name_manager = Musician.Last_name_manager;
            MusicianFromDb.Manager_contact = Musician.Manager_contact;
            MusicianFromDb.Creation_date = Musician.Creation_date;
            MusicianFromDb.Merch = Musician.Merch;
            MusicianFromDb.Discography = Musician.Discography;
            MusicianFromDb.UserId = Musician.UserId;
            MusicianFromDb.ApplicationUser = Musician.ApplicationUser;

            await _db.SaveChangesAsync();
            Message = "Musician updated successfully!";
            return RedirectToPage("MusicianList");

        }
    }
}