using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMarket.DbData;
using WebMarket.Models;

namespace WebMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Product> _productsRepository;
        public HomeController(ILogger<HomeController> logger, IRepository<Product> productsRepository)
        {
            _logger = logger;
            _productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
         
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}