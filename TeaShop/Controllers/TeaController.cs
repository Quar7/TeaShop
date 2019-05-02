using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Data.Repositories;
using TeaShop.Data.Entities;
using AutoMapper;
using TeaShop.Data.ViewModels.TeaViewModels;

namespace TeaShop.Controllers
{
    public class TeaController : Controller
    {
        private ITeaRepository _teaRepository;
        private IMapper _mapper;

        public TeaController(ITeaRepository teaRepository, IMapper mapper)
        {
            _teaRepository = teaRepository;
            _mapper = mapper;
        }

        //
        //GET: /Tea/Index
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Title"] = "Herbaty";
            var teas = _teaRepository.GetAllTeas();
            var model = _mapper.Map<IEnumerable<Tea>, IEnumerable<TeaViewModel>>(teas);
            return View(model);
        }

        //
        //GET: /Tea/Category/category
        [HttpGet("/Tea/Category/{category}")]
        public IActionResult Category(TeaCategory category)
        {
            ViewData["Title"] = "Herbaty - " + category;
            var teas = _teaRepository.GetTeasByCategory(category);
            var model = _mapper.Map<IEnumerable<Tea>, IEnumerable<TeaViewModel>>(teas);
            return View("Index", model);
        }

        //
        //GET: /Tea/Details/id
        [HttpGet]
        public IActionResult Details(int id)
        {
            var tea = _teaRepository.GetTeaById(id);
            var model = _mapper.Map<Tea, DetailsViewModel>(tea);
            return View(model);
        }

    }
}
