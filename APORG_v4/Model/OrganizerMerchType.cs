using APORG_v4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APORG_v4.Model
{
    public class OrganizerMerchType
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public int OrganizerId { get; set; }

        [ForeignKey("OrganizerId")]
        public virtual Organizer Organizer { get; set; }

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
