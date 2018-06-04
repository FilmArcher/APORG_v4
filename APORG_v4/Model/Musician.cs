using APORG_v4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APORG_v4.Model
{
    public class Musician
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "*Name")]
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Display(Name = "*Music genre")]
        [Required(ErrorMessage = "Required specification of music genre")]
        public string Genre { get; set; }

        [Display(Name = "*Country")]
        [Required(ErrorMessage = "Country required")]
        public string Country { get; set; }

        [Display(Name = "*Region")]
        [Required(ErrorMessage = "Region required")]
        public string Region { get; set; }

        [Display(Name = "*Town")]
        [Required(ErrorMessage = "Town required")]
        public string Town { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Image to upload")]
        public string Image { get; set; }

        [Display(Name = "Biography")]
        public string Biography { get; set; }

        [Display(Name = "*The first name of the manager")]
        [Required(ErrorMessage = "Required first name manager (if no manager, enter the person responsible for contacting the artist)")]
        public string First_name_manager { get; set; }

        [Display(Name = "*Manager's last name")]
        [Required(ErrorMessage = "Required last name manager (if no manager, enter the person responsible for contacting the artist)")]
        public string Last_name_manager { get; set; }

        [Display(Name = "*Manager contact number")]
        [Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Phone Number Form: 123123123")]
        [Required(ErrorMessage = "Required contact manager (if no manager, enter the person responsible for contacting the artist)")]
        public string Manager_contact { get; set; }

        [Display(Name = "*Date of creation")]
        [Required(ErrorMessage = "Required date of creation")]
        public DateTime Creation_date { get; set; }

        [Display(Name = "Merch")]
        public bool Merch { get; set; }

        [Display(Name = "Discography")]
        public bool Discography { get; set; }

        [Required]
        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
