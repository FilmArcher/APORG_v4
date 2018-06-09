using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APORG_v4.Data;
using APORG_v4.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace APORG_v4.Pages.Organizers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(ApplicationDbContext db, IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
        }

        public IList<Organizer> Organizers { get; set; }

        public async Task OnGet()
        {
            string AspNetUser_ID = Common.ExtensionMethods.getUserId(this.User);
            Organizers = await _db.Organizers.OrderBy(c => c.Name).ToListAsync();

        }
    }
}