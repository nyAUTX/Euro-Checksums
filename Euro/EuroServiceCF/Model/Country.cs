using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroServiceCF.Model
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [StringLength(3)]
        [Index(IsUnique = true)]
        public string Code { get; set; }
    }

}