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
using System.Linq;

namespace APORG_v4.Pages.Organizers
{
    [Authorize(Roles = SD.CustomerEndUser)]
    public class OrganizerListModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        [TempData]
        public string Message { get; set; }

        public OrganizerListModel(ApplicationDbContext db, IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
        }

        public IList<Organizer> Organizers { get; set; }
        
        public async Task OnGet()
        {         
            string AspNetUser_ID = Common.ExtensionMethods.getUserId(this.User);
            Organizers = await _db.Organizers.Where(c => c.UserId == AspNetUser_ID).ToListAsync();

        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var _organizer = _db.Organizers.Find(id);
            _db.Organizers.Remove(_organizer);
            await _db.SaveChangesAsync();
            
            Message = "Organizer Deleted Successfully!";           
            return RedirectToPage();
        }
    }
}