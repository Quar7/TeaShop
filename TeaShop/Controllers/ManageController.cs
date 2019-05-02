using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TeaShop.Data.Entities;
using TeaShop.Data.ViewModels.ManageViewModels;
using TeaShop.Data.Repositories;
using AutoMapper;

namespace TeaShop.Controllers
{
    [Authorize(Roles = "Customer")]
    public class ManageController : Controller
    {
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;
        private readonly string _externalCookieScheme;
        private IOrderRepository _orderRepository;
        private IMapper _mapper;

        public ManageController(
          UserManager<Customer> userManager,
          SignInManager<Customer> signInManager,
          IOptions<IdentityCookieOptions> identityCookieOptions,
          IOrderRepository orderRepository,
          IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _externalCookieScheme = identityCookieOptions.Value.ExternalCookieAuthenticationScheme;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        //
        // GET: /Manage/Index
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
            return View();
        }

        //
        // GET: /Manage/ChangeData
        [HttpGet]
        public async Task<IActionResult> ChangeData()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            var model = _mapper.Map<Customer, ChangeDataViewModel>(user);
            return View(model);
        }

        //
        // POST: /Manage/ChangeData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeData(ChangeDataViewModel model)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            if (ModelState.IsValid)
            {
                _mapper.Map(model, user);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    ViewData["StatusMessageOk"] = "Twoje dane adresowe zostały zaktualizowane.";
                }
                else
                {
                    ViewData["StatusMessageBad"] = "Wystapił błąd. Nie udało się zaktualizować danych.";
                }
            }
            return View(model);
        }

        //
        // GET: /Manage/ChangePassword
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", new { MessageOk = "Twoje hasło zostało zmienione." });
                }
                ModelState.AddModelError(string.Empty, "Niepoprawne hasło");
                return View(model);
            }
            return RedirectToAction("Index", new { MessageBad = "Przepraszamy. Wystąpił błąd." });
        }

        //
        //GET: Manage/ViewOrders
        [HttpGet]
        public async Task<IActionResult> ViewOrders()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var orders = _orderRepository.GetOrdersByCustomer(user.Id);
            var model = _mapper.Map<IEnumerable<Order>, IEnumerable<CustomerOrdersViewModel>>(orders);
            return View(model);
        }

        //
        //GET: Manage/OrderDetails/id
        [HttpGet]
        public async Task<IActionResult> OrderDetails(int id)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var order = _orderRepository.GetOrderDetailsByCustomer(user.Id, id);
            var model = _mapper.Map<Order, CustomerOrderDetailsViewModel>(order);
            return View(model);
        }

        #region Helpers

        private Task<Customer> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(User);
        }

        #endregion
    }
}
