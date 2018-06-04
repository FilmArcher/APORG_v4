﻿using APORG_v4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APORG_v4.Model
{
    public class MusicianMerchType
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public int MusicianId { get; set; }

        [ForeignKey("MusicianId")]
        public virtual Musician Musician { get; set; }

        [Display(Name ="Merch Name")]
        public string Name { get; set; }

        [Display(Name ="Price")]
        public double Price { get; set; }

        [Display(Name ="Image to upload")]
        public string Image { get; set; }

        [Display(Name = "Availability")]
        public bool Availability { get; set; }

        [Display(Name ="Description")]
        public string Description { get; set; }
    }
}
