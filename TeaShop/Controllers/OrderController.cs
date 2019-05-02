using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Data.ViewModels.OrderViewModels;
using TeaShop.Data.Repositories;
using AutoMapper;
using TeaShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace TeaShop.Controllers
{
    [Authorize(Roles = "Customer")]
    public class OrderController : Controller
    {
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;
        private IOrderRepository _orderRepository;
        private CartRepository _cartRepository;
        private ITeaRepository _teaRepository;
        private IMapper _mapper;

        public OrderController(
            UserManager<Customer> userManager,
            SignInManager<Customer> signInManager,
            IOrderRepository orderRepository,
            CartRepository cartRepository,
            ITeaRepository teaRepository,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _teaRepository = teaRepository;
            _mapper = mapper;
        }

        //
        // GET: /Order/Index
        [HttpGet]
        public async Task<IActionResult> Index(string messageOk, string messageBad)
        {
            ViewData["StatusMessageOk"] = messageOk;
            ViewData["StatusMessageBad"] = messageBad;

            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var model = new OrderViewModel();
            _mapper.Map(user, model);

            return View(model);
        }

        //
        //POST: /Order/AddOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrder(OrderViewModel model)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            _mapper.Map(model, user);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return RedirectToAction("Index", new { MessageBad = "Wystapił błąd. Nie udało się zaktualizować danych adresowych." });
            }

            var newOrder = new OrderViewModel
            {
                CustomerId = user.Id,
                Date = DateTime.Now,
                TotalAmount = _cartRepository.GetTotalAmount(),
                Payment = model.Payment,
                Delivery = model.Delivery
            };
            var orderEntity = _mapper.Map<OrderViewModel, Order>(newOrder);
            orderEntity.OrderTeas = _cartRepository.Cart;
            _orderRepository.AddOrder(orderEntity);

            if (!await _orderRepository.SaveAsync())
            {
                return RedirectToAction("Index", new { MessageBad = "Wystapił błąd. Nie udało się złozyć zamówienia." });
            }

            foreach (var orderTea in orderEntity.OrderTeas)
            {
                _teaRepository.DecreaseQuantity(orderTea.TeaId, orderTea.Quantity);
                await _teaRepository.SaveAsync();
            }
            return RedirectToAction("OrderCompleted");
        }

        //
        // GET: /Order/OrderCompleted
        [HttpGet]
        public IActionResult OrderCompleted()
        {
            _cartRepository.ClearCart();
            return View();
        }


        #region Helpers

        private Task<Customer> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(User);
        }

        #endregion

    }
}
