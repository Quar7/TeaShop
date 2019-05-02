using System;
using System.Collections.Generic;
using System.Text;
using TeaShop.Data.Entities;

namespace TeaShop.Data.ViewModels.CartViewModels
{
    public class CartLineViewModel
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal CartLineSum { get; set; }

        public Tea Tea { get; set; }
    }
}
