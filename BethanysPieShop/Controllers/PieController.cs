using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ICategoryRepository CategoryRepository => _categoryRepository;

        public PieController(IPieRepository pieRepository,  ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

         public ViewResult List()
        {
            // ViewBag.CurrentCategory = "Cheese Cakes";

            PiesListViewModel piesListViewModel = new PiesListViewModel
            {
                Pies = _pieRepository.AllPies,
                CurrentCategory = "Cheese Cakes!"
            };

            return View(piesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            return View(pie);
        }
    }
}
