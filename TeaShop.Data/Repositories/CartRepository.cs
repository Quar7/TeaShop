using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeaShop.Data.Entities;

namespace TeaShop.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        public List<OrderTea> Cart { get; set; } = new List<OrderTea>();

        public virtual void AddCartLine(Tea tea, int quantity)
        {
            var cartLine = GetCartLineByTea(tea);
            if (cartLine == null)
            {
                Cart.Add(new OrderTea
                {
                    Tea = tea,
                    Quantity = quantity,
                    Price = tea.Price
                });
            }
            else
            {
                cartLine.Quantity++;
            }
        }

        public virtual void ClearCart()
        {
            Cart.Clear();
        }

        public virtual void DecreaseCartLineQuantity(Tea tea)
        {
            var cartLine = GetCartLineByTea(tea);
            if (cartLine.Quantity > 1)
            {
                cartLine.Quantity--;
            }
        }

        public virtual OrderTea GetCartLineByTea(Tea tea)
        {
            return Cart.Where(c => c.Tea.Id == tea.Id).FirstOrDefault();
        }

        public decimal GetCartLineSum(Tea tea)
        {
            return Cart.Where(c => c.Tea.Id == tea.Id).Sum(c => c.Tea.Price * c.Quantity);
        }

        public virtual decimal GetTotalAmount()
        {
            return Cart.Sum(c => c.Tea.Price * c.Quantity);
        }

        public virtual void RemoveCartLine(Tea tea)
        {
            Cart.RemoveAll(c => c.Tea.Id == tea.Id);
        }
    }
}
