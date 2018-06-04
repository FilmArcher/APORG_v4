using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APORG_v4.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<Model.Object> Object { get; set; }
        public IEnumerable<Model.Musician> Musician { get; set; }
        //public IEnumerable<Model.Organizer> Organizer { get; set; }

    }
}
