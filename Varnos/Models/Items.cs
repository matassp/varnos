using System;
using System.Collections.Generic;

namespace Varnos.Models
{
    public partial class Items
    {
        public Items()
        {
            ItemPointMap = new HashSet<ItemPointMap>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int IdItem { get; set; }

        public ICollection<ItemPointMap> ItemPointMap { get; set; }
    }
}
