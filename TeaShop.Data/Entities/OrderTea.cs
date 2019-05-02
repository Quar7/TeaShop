using System;
using System.Collections.Generic;
using System.Text;

namespace TeaShop.Data.Entities
{
    public class OrderTea
    {
        public int OrderId { get; set; }
        public int TeaId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Tea Tea { get; set; }
    }
}
