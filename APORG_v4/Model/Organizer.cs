using APORG_v4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APORG_v4.Model
{
    public class Organizer
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required(ErrorMessage = "Required name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required country")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Required region")]
        [Display(Name = "Region")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Required town")]
        [Display(Name = "Town")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Required contact")]
        [Phone]
        [Display(Name = "Contact")]
        public string Contact { get; set; }

    }
}
