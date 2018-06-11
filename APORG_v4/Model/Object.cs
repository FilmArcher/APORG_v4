using APORG_v4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Spatial;
using System.Threading.Tasks;

namespace APORG_v4.Model
{
    public class Object
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "*Name")]
        [StringLength(69)]
        [Required(ErrorMessage = "Required Object name")]
        public string object_name { get; set; }

        [Display(Name = "*Country")]
        [StringLength(69)]
        [Required(ErrorMessage = "Required country")]
        public string country { get; set; }

        [Display(Name = "*Region")]
        [StringLength(69)]
        [Required(ErrorMessage = "Required region")]
        public string region { get; set; }

        [Display(Name = "*Town")]
        [StringLength(69)]
        [Required(ErrorMessage = "Required town")]
        public string town { get; set; }

        [Display(Name = "*Street name")]
        [StringLength(69)]
        [Required(ErrorMessage = "Required street name")]
        public string street { get; set; }

        [Display(Name = "*Number of building / place")]
        [Required(ErrorMessage = "Required number of building / place")]
        public int no_building { get; set; }

        [Display(Name = "*postal-code")]
        [Required(ErrorMessage = "Required postal code")]
        public string post_code { get; set; }

        [Display(Name ="Object descryption")]
        [StringLength(300)]
        public string object_desc { get; set; }

        [Display(Name = "Manager first name")]
        [StringLength(69)]
        public string manager_name { get; set; }

        [Display(Name = "Manager last name")]
        [StringLength(69)]
        public string manager_lastname { get; set; }

        [Display(Name = "Manager phone number")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Phone Number Form: 123123123")]
        public string manager_contact { get; set; }

        [Display(Name = "Manager E-mail")]
        [EmailAddress]
        public string manager_email { get; set; }

        [Display(Name = "*Area of the object")]
        [Required(ErrorMessage = "Required surface specification of the object")]
        public double object_surface { get; set; }

        [Display(Name = "*Object Cubature")]
        [Required(ErrorMessage = "Required specification of the cubic capacity of the facility ( the number of people the object will be in )")]
        public int cubature { get; set; }

        [Display(Name = "Stage")]
        public bool stage { get; set; }

        [Display(Name = "Stage surface")]
        public string stage_surface { get; set; }

        [Display(Name = "Stage comments")]
        public string Stage_comments { get; set; }

        [Display(Name = "Parking")]
        public bool parking { get; set; }

        [Display(Name = "Backstage")]
        public bool backstage { get; set; }

        [Display(Name = "Backstage surface")]
        public string backstage_surface { get; set; }

        [Display(Name = "Description of the backstage")]
        [DataType(DataType.MultilineText)]
        public string backstage_description { get; set; }

        [Display(Name = "Cloakroom")]
        public bool cloakroom { get; set; }

        [Display(Name = "Garden")]
        public bool garden { get; set; }

        [Display(Name = "Acoustics")]
        public bool acoustics { get; set; }

        [Display(Name = "Acoustics phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Phone Number Form: 123123123")]
        public string acoustics_contact { get; set; }

        [Display(Name = "Safeguard")]
        public bool safeguard { get; set; }

        [Display(Name = "Lights")]
        public bool lights { get; set; }

        [Display(Name = "Description of the lights")]
        [DataType(DataType.MultilineText)]
        public string lights_description { get; set; }

        [Display(Name = "Lighting technician")]
        public bool lighting_technician { get; set; }

        [Display(Name = "Lighting technician phone number")]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Phone Number Form: 123123123")]
        public string lighting_technician_contact { get; set; }

        [Display(Name = "Bar")]
        public bool bar { get; set; }

        [Display(Name = "Bar descryption")]
        public string bar_desc { get; set; }

        [Display(Name = "Frontline")]
        public bool frontline { get; set; }

        [Display(Name = "Description of the Frontline")]
        [DataType(DataType.MultilineText)]
        public string frontline_description { get; set; }

        [Display(Name = "Backline")]
        public bool backline { get; set; }

        [Display(Name = "Description of the backline")]
        [DataType(DataType.MultilineText)]
        public string backline_description { get; set; }

        [Display(Name = "Image to upload")]
        public string Image { get; set; }

        [Required]
        public string UserId { get; set; }

        [NotMapped]
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
