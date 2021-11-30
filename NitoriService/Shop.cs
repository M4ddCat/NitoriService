using System;
using System.Collections.Generic;

namespace NitoriService
{
    public partial class Shop
    {
        public Shop()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string EquipmentTitle { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
