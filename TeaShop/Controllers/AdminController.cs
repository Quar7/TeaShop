using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Data.Repositories;
using TeaShop.Data.ViewModels.TeaViewModels;
using AutoMapper;
using TeaShop.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using TeaShop.Data.ViewModels.AdminViewModels;

namespace TeaShop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private ITeaRepository _teaRepository;
        private IOrderRepository _orderRepository;
        private IMapper _mapper;

        public AdminController(ITeaRepository teaRepository, IOrderRepository orderRepository, IMapper mapper)
        {
            _teaRepository = teaRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        //
        //GET: /Admin/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //
        //GET: /Admin/Products
        [HttpGet]
        public IActionResult Products(string messageOk, string messageBad)
        {
            ViewData["StatusMessageOk"] = messageOk;
            ViewData["StatusMessageBad"] = messageBad;

            var teas = _teaRepository.GetAllTeas();
            var model = _mapper.Map<IEnumerable<Tea>, IEnumerable<TeaViewModel>>(teas);
            return View(model);
        }

        //
        //GET: /Admin/EditProduct/id
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var tea = _teaRepository.GetTeaById(id);
            var model = _mapper.Map<Tea, DetailsViewModel>(tea);
            return View(model);
        }

        //
        //POST: /Admin/EditProduct/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, DetailsViewModel model)
        {
            var tea = _teaRepository.GetTeaById(id);
            if (ModelState.IsValid)
            {
                _mapper.Map(model, tea);
                _teaRepository.UpdateTea(tea);

                if (await _teaRepository.SaveAsync())
                {
                    ViewData["StatusMessageOk"] = "Produkt został zaktualizowany.";
                    var updatedTea = _mapper.Map<Tea, DetailsViewModel>(tea);
                    return View(updatedTea);
                }
                else
                {
                    ViewData["StatusMessageBad"] = "Wystapił błąd. Nie udało się zaktualizować produktu.";
                }
            };
            return View(model);
        }

        //
        //GET: /Admin/AddProduct
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        //
        //POST: /Admin/AddProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(DetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newTea = new Tea();
                _mapper.Map(model, newTea);
                _teaRepository.AddTea(newTea);

                if (await _teaRepository.SaveAsync())
                {
                    return RedirectToAction("Products", new { MessageOk = "Dodano nowy produkt." });
                }
                else
                {
                    return RedirectToAction("Products", new { MessageBad = "Wystapił błąd. Nie udało się dodać produktu." });
                }
            }
            return View(model);
        }

        //
        //POST: /Admin/DeleteProduct/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateProduct(int id)
        {
            var tea = _teaRepository.GetTeaById(id);
            _teaRepository.DeactivateTea(tea);

            if (await _teaRepository.SaveAsync())
            {
                return RedirectToAction("Products", new { MessageOk = $"Produkt \"{tea.Name}\" został usunięty." });
            }
            else
            {
                return RedirectToAction("Products", new { MessageBad = "Wystapił błąd. Nie udało się usunąć produktu." });
            }
        }

        //
        //GET: Admin/Orders
        [HttpGet]
        public IActionResult Orders()
        {
            var orders = _orderRepository.GetAllOrders();
            var model = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderListViewModel>>(orders);
            return View(model);
        }

        //
        //GET: Admin/OrderDetails/id
        [HttpGet]
        public IActionResult OrderDetails(int id, string messageOk, string messageBad)
        {
            ViewData["StatusMessageOk"] = messageOk;
            ViewData["StatusMessageBad"] = messageBad;

            var order = _orderRepository.GetOrderById(id);
            var model = _mapper.Map<Order, OrderDetailsViewModel>(order);
            return View(model);
        }

        //
        //POST: Admin/ChangeStatus/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            var order = _orderRepository.GetOrderById(id);

            if (ModelState.IsValid)
            {
                order.Completed = true;
            }
            _orderRepository.UpdateState(order);

            if (await _orderRepository.SaveAsync())
            {
                return RedirectToAction("OrderDetails", new { Id = id, MessageOk = $"Zamówienie zostało zrealizowane." });
            }
            else
            {
                return RedirectToAction("OrderDetails", new { Id = id, MessageBad = "Wystapił błąd. Nie udało się zmienić statusu zamówienia." });
            }
        }
    }
}
