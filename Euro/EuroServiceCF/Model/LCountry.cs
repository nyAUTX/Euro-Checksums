using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EuroServiceCF.Model
{
    public class LCountry
    {
        [Key, Column(Order = 0)]
        public int CountryId { get; set; }

        [Key, Column(Order = 1)]
        public int LanguageId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
    }

}