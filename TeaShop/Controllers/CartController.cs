using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TeaShop.Data.Repositories;
using TeaShop.Data.ViewModels.CartViewModels;
using TeaShop.Data.Entities;
using AutoMapper;

namespace TeaShop.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : Controller
    {
        private ITeaRepository _teaRepository;
        private CartRepository _cartRepository;
        private IMapper _mapper;

        public CartController(ITeaRepository teaRepository, CartRepository cartRepository, IMapper mapper)
        {
            _teaRepository = teaRepository;
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        //
        // GET: /Cart/Index
        [HttpGet]
        public IActionResult Index(string messageBad)
        {
            ViewData["StatusMessageBad"] = messageBad;

            var cart = _cartRepository.Cart;
            var model = new CartViewModel
            {
                CartLine = _mapper.Map<IEnumerable<OrderTea>, IEnumerable<CartLineViewModel>>(cart),
                TotalAmount = _cartRepository.GetTotalAmount()
            };

            return View(model);
        }

        //
        // POST: /Cart/AddToCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int id)
        {
            var tea = _teaRepository.GetTeaById(id);
            var cartLine = _cartRepository.GetCartLineByTea(tea);
            if (cartLine == null || cartLine.Quantity < tea.Quantity)
            {
                _cartRepository.AddCartLine(tea, 1);
            }
            else
            {
                return RedirectToAction("Index", new { MessageBad = $"Dostepne jest jedynie {tea.Quantity} sztuk herbaty {tea.Name}." });
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Cart/IncreaseCartLineQuantity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IncreaseCartLineQuantity(int id)
        {
            var tea = _teaRepository.GetTeaById(id);
            var cartLine = _cartRepository.GetCartLineByTea(tea);
            if (cartLine == null || cartLine.Quantity < tea.Quantity)
            {
                _cartRepository.AddCartLine(tea, 1);
                var cartLineQuantity = _cartRepository.GetCartLineByTea(tea).Quantity;
                var cartLineSum = _cartRepository.GetCartLineSum(tea).ToString();
                var cartTotalAmount = _cartRepository.GetTotalAmount().ToString();
                return Json(new
                {
                    Quantity = cartLineQuantity,
                    Sum = cartLineSum,
                    TotalAmount = cartTotalAmount
                });
            }
            else
            {
                return Json($"Dostepne jest jedynie {tea.Quantity} sztuk herbaty {tea.Name}.");
            }
        }

        //
        // POST: /Cart/DecreaseCartLineQuantity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DecreaseCartLineQuantity(int id)
        {
            var tea = _teaRepository.GetTeaById(id);
            _cartRepository.DecreaseCartLineQuantity(tea);
            var cartLineQuantity = _cartRepository.GetCartLineByTea(tea).Quantity;
            var cartLineSum = _cartRepository.GetCartLineSum(tea).ToString();
            var cartTotalAmount = _cartRepository.GetTotalAmount().ToString();
            return Json(new
            {
                Quantity = cartLineQuantity,
                Sum = cartLineSum,
                TotalAmount = cartTotalAmount
            });
        }

        //
        // POST: /Cart/RemoveFromCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromCart(int id)
        {
            var tea = _teaRepository.GetTeaById(id);
            _cartRepository.RemoveCartLine(tea);
            return RedirectToAction("Index");
        }

        //
        // POST: /Cart/ClearCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ClearCart()
        {
            _cartRepository.ClearCart();
            return RedirectToAction("Index");
        }
    }
}
