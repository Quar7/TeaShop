using System;
using System.Collections.Generic;
using System.Text;
using TeaShop.Data.Entities;

namespace TeaShop.Data.Repositories
{
    public interface ICartRepository
    {
        OrderTea GetCartLineByTea(Tea tea);
        void AddCartLine(Tea tea, int quantity);
        void DecreaseCartLineQuantity(Tea tea);
        void RemoveCartLine(Tea tea);
        void ClearCart();
        decimal GetTotalAmount();
        decimal GetCartLineSum(Tea tea);
    }
}
