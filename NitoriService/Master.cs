using System;
using System.Collections.Generic;

namespace NitoriService
{
    public partial class Master
    {
        public Master()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string SecondName { get; set; } = null!;
        public string Qualification { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
