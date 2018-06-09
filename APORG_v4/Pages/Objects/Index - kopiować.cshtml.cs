using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APORG_v4.Data;
using APORG_v4.Model;
using APORG_v4.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APORG_v4.Pages.Objects
{
    public class IndexModel2 : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;

        public IndexModel2(ApplicationDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public IndexViewModel IndexVM { get; set; }

        public async Task OnGet(string option = null, string search = null)
        {
            if (search != null)
            {
                var user = new ApplicationUser();
                List<Model.Object> ObjectList = new List<Model.Object>();
                if (option == "name")
                {
                    ObjectList = _db.Objects.Where(o => o.Id == Convert.ToInt32(search)).ToList();
                }
                else
                {
                    if (option == "country")
                    {
                        //ObjectList = _db.Objects.Where(o => o.country.ToLower().Contains(search.ToLower())).FirstOrDefault();
                        ObjectList = _db.Objects.Where(o => o.country == Convert.ToString(search)).ToList();
                    }
                    else
                    {
                        if (option == "region")
                        {
                            ObjectList = _db.Objects.Where(o => o.region == Convert.ToString(search)).ToList();
                        }
                        else
                        {
                            if (option == "town")
                            {
                                ObjectList = _db.Objects.Where(o => o.town == Convert.ToString(search)).ToList();
                            }
                        }
                    }
                }

                if (user != null || ObjectList.Count > 0)
                {
                    if (ObjectList.Count == 0)
                    {
                        ObjectList = _db.Objects.Where(o => o.UserId == user.Id).OrderByDescending(o => o.object_name).ToList();
                    }

                    IndexVM = new IndexViewModel()
                    {
                        Object = _db.Objects.OrderBy(m => m.object_name),
                    };
                }
            }
            else
            {



                IndexVM = new IndexViewModel()
                {
                    Object = _db.Objects.OrderBy(m => m.object_name),
                };
            }
        }
    }
}