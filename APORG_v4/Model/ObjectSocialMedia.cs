using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APORG_v4.Model
{
    public class ObjectSocialMedia
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public int ObjectId { get; set; }

        [ForeignKey("ObjectId")]
        public virtual Object Object { get; set; }

        [Display(Name = "Media Name")]
        [StringLength(69)]
        public string MediaName { get; set; }

        [Display(Name = "Url Address")]
        [DataType(DataType.Url)]
        public string UrlAddress { get; set; }

    }
}
