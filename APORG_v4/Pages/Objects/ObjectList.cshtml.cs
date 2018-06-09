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

namespace APORG_v4.Pages.Objects
{
    [Authorize(Roles = SD.CustomerEndUser)]
    public class ObjectListModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        [TempData]
        public string Message { get; set; }

        public ObjectListModel(ApplicationDbContext db, IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
        }

        public IList<Object> Objects { get; set; }
        
        public async Task OnGet()
        {         
            string AspNetUser_ID = Common.ExtensionMethods.getUserId(this.User);
            Objects = await _db.Objects.Where(c => c.UserId == AspNetUser_ID).ToListAsync();

            
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var _object = _db.Objects.Find(id);
            _db.Objects.Remove(_object);
            await _db.SaveChangesAsync();
            
            Message = "Object Deleted Successfully!";           
            return RedirectToPage();
        }
    }
}