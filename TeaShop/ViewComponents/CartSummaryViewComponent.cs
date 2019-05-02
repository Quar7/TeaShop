using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaShop.Data.Entities;
using TeaShop.Data.Repositories;
using TeaShop.Data.ViewModels.CartViewModels;

namespace TeaShop.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private CartRepository _cartRepository;
        private IMapper _mapper;

        public CartSummaryViewComponent(CartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            var cart = _cartRepository.Cart;
            var model = new CartViewModel
            {
                CartLine = _mapper.Map<IEnumerable<OrderTea>, IEnumerable<CartLineViewModel>>(cart),
                TotalAmount = _cartRepository.GetTotalAmount()
            };
            return Task.FromResult<IViewComponentResult>(View(model));
        }
    }
}
