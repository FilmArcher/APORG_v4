using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APORG_v4.Model
{
    public class Ticket
    {
        [Required]
        public int Id { get; set; }
        
        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }

        [Required(ErrorMessage = "Required ticket type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Required ticket price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Required ticket availability")]
        public bool Availability { get; set; }

        [Required(ErrorMessage = "Required ticket hyperlink (Where u can buy ticket)")]
        [DataType(DataType.Url)]
        public string Hyperlink { get; set; }

    }
}
