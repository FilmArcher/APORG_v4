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
    public class MusicianDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public MusicianDetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Musician Musician { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
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
    }
}