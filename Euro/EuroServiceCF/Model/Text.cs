using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EuroServiceCF.Model
{
    public class Text
    {
        public int TextId { get; set; }

        [Required]
        [MaxLength(255)]
        [Index(IsUnique = true)]
        public string Desc { get; set; }
    }

}