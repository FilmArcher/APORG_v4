using APORG_v4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace APORG_v4.Model
{
    public class Event
    {
        [Key]
        [Required]
        [ScaffoldColumn(false)]
        public int id { get; set; }    

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Event Name")]
        [Required(ErrorMessage = "Required event name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required event date")]
        [Display(Name = "Event Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Event Place")]
        [Required(ErrorMessage = "Required event place")]
        public Object Place { get; set; }

        [Display(Name = "Event Descryption")]
        [Required(ErrorMessage = "Required event descryption")]
        public string Descryption { get; set; }

        [Display(Name = "Event image to upload")]
        public string Image { get; set; }

        [Display(Name = "Tickets")]
        public string Tickets { get; set; }
    }
}
