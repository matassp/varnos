using System;
using System.Collections.Generic;

namespace Varnos.Models
{
    public partial class Users
    {
        public Users()
        {
            Points = new HashSet<Points>();
        }

        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int IdUser { get; set; }
        public int FkRegionidRegion { get; set; }

        public Regions FkRegionidRegionNavigation { get; set; }
        public ICollection<Points> Points { get; set; }
    }
}
