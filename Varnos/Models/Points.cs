using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

namespace Varnos.Models
{
    public partial class Points
    {
        public Points()
        {
            ItemPointMap = new HashSet<ItemPointMap>();
        }

        [Required]
        public decimal? Latitude { get; set; }
        [Required]
        public decimal? Longitude { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? Date { get; set; }
        [Required]
        public int IdPoint { get; set; }
        [Required]
        public int FkUseridUser { get; set; }
        [Required]
        public int FkRegionidRegion { get; set; }

        public Regions FkRegionidRegionNavigation { get; set; }
        public Users FkUseridUserNavigation { get; set; }
        public ICollection<ItemPointMap> ItemPointMap { get; set; }
    }
}
