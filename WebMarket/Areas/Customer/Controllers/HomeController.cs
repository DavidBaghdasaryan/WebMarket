using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using WebMarket.DbData;
using WebMarket.Models;

namespace WebMarket.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Product> _productsRepository;
        private readonly IMemoryCache _cache;
        public HomeController(ILogger<HomeController> logger,
            IRepository<Product> productsRepository,
             IMemoryCache cache)
        {
            _logger = logger;
            _productsRepository = productsRepository;
            _cache = cache;
        }

        public  IActionResult Index()
        {
            string cacheKey = "CachedData";

            // Проверяем наличие данных в кэше
            if (!_cache.TryGetValue(cacheKey, out List<Product> data))
            {
                data =  _productsRepository.GetAll().ToList();

                // Сохраняем полученные данные в кэше с определенным временем жизни
                _cache.Set(cacheKey, data, TimeSpan.FromMinutes(30));
            }
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