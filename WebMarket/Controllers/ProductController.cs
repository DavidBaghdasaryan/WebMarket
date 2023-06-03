using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebMarket.DbData;
using WebMarket.Models;

namespace WebMarket.Controllers
{
    public class ProductController:Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IRepository<Product> _productsRepository;
        public ProductController(IWebHostEnvironment webHostEnvironment, IRepository<Product> productsRepository)
        {
            _webHostEnvironment= webHostEnvironment;
            _productsRepository= productsRepository;
        }
        public IActionResult Index() 
        {
            Product product = new Product();
            ///product.ImageUrl = "C:\\Users\\david\\source\\repos\\Bulk\\BulkWeb\\wwwroot\\Images\\product\\630d5d64-b8c8-4d60-8821-f7ff79dfbd73.jpg";
            return View(product);
        }
        public IActionResult UpSert(int? id)
        {
            Product Product = new()
            {
                
                
            };
            if (id == null || id == 0)
            {
                return View(Product);
            }
            else
            {
                
                return View(Product);
            }

        }
        [HttpPost]
        public IActionResult UpSert(Product Product, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRotPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRotPath, @"images\product");
                    if (!string.IsNullOrEmpty(Product.ImageUrl))
                    {
                        var oldImage = Path.Combine(wwwRotPath, Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImage))
                        {
                            System.IO.File.Delete(oldImage);
                        }
                    }
                    using (var filestrim = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(filestrim);
                    }
                    Product.ImageUrl = @"\images\product\" + fileName;
                }
                if (Product.Id == 0)
                {
                    _productsRepository.Add(Product);
                }
                else
                {
                    _productsRepository.Update(Product);
                }

                _productsRepository.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
               
                return View(Product);
            }
        }
    }
}
