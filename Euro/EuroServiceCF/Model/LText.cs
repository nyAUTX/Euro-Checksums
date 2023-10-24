using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace EuroServiceCF.Model
{
    public class LText
    {
        [Key, Column(Order = 0)]
        public int TextId { get; set; }

        [Key, Column(Order = 1)]
        public int LanguageId { get; set; }

        [Required]
        [MaxLength(255)]
        [Index(IsUnique = true)]
        public string Text { get; set; }

        [ForeignKey("TextId")]
        public Text TextEntity { get; set; }

        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
    }

}