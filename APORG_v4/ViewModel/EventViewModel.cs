using APORG_v4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APORG_v4.ViewModel
{
    public class EventViewModel
    {

        public Event Event { get; set; }
        public IEnumerable<Model.Object> Object { get; set; }

    }
}
