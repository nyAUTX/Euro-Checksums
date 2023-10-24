using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroServiceCF.Model
{
    public class Printery
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1)]
        public string Code { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int Circulation { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }
    }

}