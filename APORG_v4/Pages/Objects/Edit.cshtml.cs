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

namespace APORG_v4.Pages.Objects
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
        public Model.Object Object{ get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if(id == null)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                return Page();

            }

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var ObjectFromDb = _db.Objects.Where(m => m.Id == Object.Id).FirstOrDefault();

            if (files[0] != null && files[0].Length >0)
            {
                var uploads = Path.Combine(webRootPath, "images");
                var extension = ObjectFromDb.Image.Substring(ObjectFromDb.Image.LastIndexOf("."), ObjectFromDb.Image.Length - ObjectFromDb.Image.LastIndexOf("."));

                if(System.IO.File.Exists(Path.Combine(uploads,Object.Id+extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, Object.Id + extension));
                }

                extension = files[0].FileName.Substring(files[0].FileName.LastIndexOf("."), files[0].FileName.Length - files[0].FileName.LastIndexOf("."));
                using (var fileStream = new FileStream(Path.Combine(uploads, Object.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                Object.Image = @"\images\" + Object.Id + extension;
            }


            if (Object.Image != null)
            {
                ObjectFromDb.Image = Object.Image;
            }
            ObjectFromDb.object_name = Object.object_name;
            ObjectFromDb.country = Object.country;
            ObjectFromDb.region = Object.region;
            ObjectFromDb.town = Object.town;
            ObjectFromDb.street = Object.street;
            ObjectFromDb.no_building = Object.no_building;
            ObjectFromDb.post_code = Object.post_code;
            ObjectFromDb.object_desc = Object.object_desc;
            ObjectFromDb.manager_name = Object.manager_name;
            ObjectFromDb.manager_lastname = Object.manager_lastname;
            ObjectFromDb.manager_contact = Object.manager_contact;
            ObjectFromDb.manager_email = Object.manager_email;
            ObjectFromDb.object_surface = Object.object_surface;
            ObjectFromDb.cubature = Object.cubature;
            ObjectFromDb.stage = Object.stage;
            ObjectFromDb.stage_surface = Object.stage_surface;
            ObjectFromDb.parking = Object.parking;
            ObjectFromDb.backstage = Object.backstage;
            ObjectFromDb.backstage_surface = Object.backstage_surface;
            ObjectFromDb.backstage_description = Object.backstage_description;
            ObjectFromDb.cloakroom = Object.cloakroom;
            ObjectFromDb.garden = Object.garden;
            ObjectFromDb.acoustics = Object.acoustics;
            ObjectFromDb.acoustics_contact = Object.acoustics_contact;
            ObjectFromDb.safeguard = Object.safeguard;
            ObjectFromDb.lights = Object.lights;
            ObjectFromDb.lights_description = Object.lights_description;
            ObjectFromDb.lighting_technician = Object.lighting_technician;
            ObjectFromDb.lighting_technician_contact = Object.lighting_technician_contact;
            ObjectFromDb.bar = Object.bar;
            ObjectFromDb.bar_desc = Object.bar_desc;
            ObjectFromDb.frontline = Object.frontline;
            ObjectFromDb.frontline_description = Object.frontline_description;
            ObjectFromDb.backline = Object.backline;
            ObjectFromDb.backline_description = Object.backline_description;

            //_db.Attach(Object).State = EntityState.Modified;

            await _db.SaveChangesAsync();
            Message = "Object updated successfully!";
            return RedirectToPage("ObjectList");

        }
    }
}