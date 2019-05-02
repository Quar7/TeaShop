using System;
using System.Collections.Generic;
using System.Text;

namespace TeaShop.Data.ViewModels.CartViewModels
{
    public class CartViewModel
    {
        public IEnumerable<CartLineViewModel> CartLine { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
