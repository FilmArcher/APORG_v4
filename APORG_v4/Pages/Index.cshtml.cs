﻿using System.Linq;
using System.Threading.Tasks;
using APORG_v4.Model;
using APORG_v4.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APORG_v4.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;

        public IndexModel(ApplicationDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public IndexViewModel IndexVM { get; set; }

        public async Task OnGet()
        {
            IndexVM = new IndexViewModel()
            {
                Object = _db.Objects.OrderBy(m => m.object_name),
                //Musician = _db.Musicians.OrderBy(c => c.Name)
            };
        }
    }
}
