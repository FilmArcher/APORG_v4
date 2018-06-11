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
        [ScaffoldColumn(false)]
        public int id { get; set; }    

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Required event name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required event date")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Place")]
        public int ObjectId { get ; set; }

        [ForeignKey("ObjectId")]
        public virtual Object Object { get; set; }
       
        [Display(Name = "Descryption")]
        [Required(ErrorMessage = "Required event descryption")]
        public string Descryption { get; set; }

        [Display(Name = "Image to upload")]
        public string Image { get; set; }

        [Display(Name = "Tickets")]
        public int TicketId { get; set; }
    }
}
