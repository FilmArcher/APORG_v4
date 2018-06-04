using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using APORG_v4.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using APORG_v4.Utility;
using Microsoft.AspNetCore.Identity;
using APORG_v4.Data;

namespace APORG_v4.Pages.Musicians
{
    [Authorize(Roles = SD.CustomerEndUser)]
    public class MusicianListModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        [TempData]
        public string Message { get; set; }

        public MusicianListModel(ApplicationDbContext db, IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
        }

        public IEnumerable<Musician> Musicians { get; set; }
        
        public async Task OnGet()
        {         
            string AspNetUser_ID = Common.ExtensionMethods.getUserId(this.User);
            Musicians = await _db.Musicians.ToListAsync();
            
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var _musician = _db.Musicians.Find(id);
            _db.Musicians.Remove(_musician);
            await _db.SaveChangesAsync();
            
            Message = "Musician Deleted Successfully!";           
            return RedirectToPage();
        }
    }
}