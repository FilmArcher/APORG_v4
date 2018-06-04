using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APORG_v4.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace APORG_v4.Pages
{
    public class ObjectDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ObjectDetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Model.Object Object { get; set; }

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
    }
}