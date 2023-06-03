using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebMarket.Controllers
{
    public class ProductController:Controller
    {
        public IActionResult Index() 
        {
            return View();
        }
    }
}
