using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroServiceCF.Model
{
    public class OldSeries
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1)]
        public string Code { get; set; }

        public int CountryId { get; set; }
        public bool Circulation { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }

}