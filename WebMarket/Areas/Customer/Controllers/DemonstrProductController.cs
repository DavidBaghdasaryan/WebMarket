using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMarket.DbData;
using WebMarket.Models;

namespace WebMarket.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class DemonstrProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Product> _productsRepository;

        public DemonstrProductController(ILogger<HomeController> logger, IRepository<Product> productsRepository)
        {
            _logger = logger;
            _productsRepository = productsRepository;
        }

     
        public IActionResult AllProductsDemoList()
        {
            var productList = _productsRepository.GetAll().ToList();
            return View(productList);
        }

      
    }
}