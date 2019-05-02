using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeaShop.Data.Repositories;

namespace TeaShop.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private CartRepository _cartRepository;
        private IMapper _mapper;

        public CartViewComponent(CartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            var isCartNotEmpty = _cartRepository.Cart.Any();
            return Task.FromResult<IViewComponentResult>(View(isCartNotEmpty));
        }
    }
}
