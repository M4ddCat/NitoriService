using System;
using System.Collections.Generic;

namespace NitoriService
{
    public partial class Order
    {
        public int ShopId { get; set; }
        public int MasterId { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public bool? Completed { get; set; }

        public virtual Master Master { get; set; } = null!;
        public virtual Shop Shop { get; set; } = null!;
    }
}
