﻿using APORG_v4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APORG_v4.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<Model.Object> Object { get; set; }
        public IEnumerable<Musician> Musician { get; set; }
        public IEnumerable<Organizer> Organizer { get; set; }

    }
}
