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
        public Event Event { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if(id == null)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                return Page();

            }

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var EventFromDb = _db.Events.Where(m => m.id == Event.id).FirstOrDefault();

            if (files[0] != null && files[0].Length >0)
            {
                var uploads = Path.Combine(webRootPath, "images");
                var extension = EventFromDb.Image.Substring(EventFromDb.Image.LastIndexOf("."), EventFromDb.Image.Length - EventFromDb.Image.LastIndexOf("."));

                if(System.IO.File.Exists(Path.Combine(uploads, Event.id+extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, Event.id + extension));
                }

                extension = files[0].FileName.Substring(files[0].FileName.LastIndexOf("."), files[0].FileName.Length - files[0].FileName.LastIndexOf("."));
                using (var fileStream = new FileStream(Path.Combine(uploads, Event.id + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                Event.Image = @"\images\" + Event.id + extension;
            }


            if (Event.Image != null)
            {
                EventFromDb.Image = Event.Image;
            }
            EventFromDb.Name = Event.Name;
            EventFromDb.Date = Event.Date;
            EventFromDb.Place = Event.Place;
            EventFromDb.Descryption = Event.Descryption;
            EventFromDb.Tickets = Event.Tickets;

            await _db.SaveChangesAsync();
            Message = "Event updated successfully!";
            return RedirectToPage("EventList");

        }
    }
}