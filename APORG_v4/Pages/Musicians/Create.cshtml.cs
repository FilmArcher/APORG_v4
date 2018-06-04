using System.IO;
using System.Threading.Tasks;
using APORG_v4.Data;
using APORG_v4.Model;
using APORG_v4.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace APORG_v4.Pages.Musicians
{
    [Authorize(Roles = SD.CustomerEndUser)]

        public class CreateModel : PageModel
        {
            private readonly ApplicationDbContext _db;
            private readonly IHostingEnvironment _hostingEnvironment;
            private readonly UserManager<ApplicationUser> _userManager;

            [TempData]
            public string Message { get; set; }

            public CreateModel(ApplicationDbContext db, IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager)
            {
                _db = db;
                _hostingEnvironment = hostingEnvironment;
                _userManager = userManager;
            }
            [BindProperty]
            public Musician Musician { get; set; }

            public async Task<IActionResult> OnGet(string id)
            {
                string AspNetUser_ID = Common.ExtensionMethods.getUserId(this.User);

                var User = await _db.Users.SingleOrDefaultAsync(a => a.Id == AspNetUser_ID);
                if (User == null)
                {
                    return NotFound();
                }
                return Page();
            }

            public async Task<IActionResult> OnPostAsync()
            {
                string AspNetUser_ID = Common.ExtensionMethods.getUserId(this.User);

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                Musician.UserId = AspNetUser_ID;
                _db.Musicians.Add(Musician);



                //Image Being Saved

                string webRootPath = _hostingEnvironment.WebRootPath;

                var files = HttpContext.Request.Form.Files;

                var MusicianFromDb = _db.Musicians.Find(Musician.Id);

                if (files[0] != null && files[0].Length > 0)
                {
                    var uploads = Path.Combine(webRootPath, "images");
                    var extension = files[0].FileName.Substring(files[0].FileName.LastIndexOf("."), files[0].FileName.Length - files[0].FileName.LastIndexOf("."));

                    using (var fileStream = new FileStream(Path.Combine(uploads, Musician.Id + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                MusicianFromDb.Image = @"\images\" + Musician.Id + extension;
                }
                else
                {
                    var uploads = Path.Combine(webRootPath, @"images\" + SD.DefaultMusicianImage);
                    System.IO.File.Copy(uploads, webRootPath + @"\images\" + Musician.Id + ".png");
                MusicianFromDb.Image = @"\images\" + Musician.Id + ".png";
                }
                await _db.SaveChangesAsync();
                Message = "New Musician Added Successfully!";
                return RedirectToPage("MusicianList");
            }
        }
}
