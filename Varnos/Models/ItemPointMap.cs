using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Varnos.Models
{
    public partial class ItemPointMap
    {
        [Display(Name="Species")]
        [Required]
        public int FkItemidItem { get; set; }
        [Display(Name = "Point")]
        [Required]
        public int FkPointidPoint { get; set; }
        [Range(1, 1000)]
        [CustomValidator(1, 10)]
        [Required]
        public int? Quantity { get; set; }

        public Items FkItemidItemNavigation { get; set; }
        public Points FkPointidPointNavigation { get; set; }
    }
}
