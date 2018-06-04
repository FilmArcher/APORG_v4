using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APORG_v4.Model
{
    public class MusicianSocialMedia
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public int MusicianId { get; set; }

        [ForeignKey("MusicianId")]
        public virtual Musician Musician { get; set; }

        [Display(Name = "Media Name")]
        [StringLength(69)]
        public string MediaName { get; set; }

        [Display(Name = "Url Address")]
        [DataType(DataType.Url)]
        public string UrlAddress { get; set; }

    }
}
