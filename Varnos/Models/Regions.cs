using System;
using System.Collections.Generic;

namespace Varnos.Models
{
    public partial class Regions
    {
        public Regions()
        {
            Points = new HashSet<Points>();
            Users = new HashSet<Users>();
        }

        public string Name { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? Zoom { get; set; }
        public int IdRegion { get; set; }

        public ICollection<Points> Points { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
