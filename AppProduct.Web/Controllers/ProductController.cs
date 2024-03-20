using Microsoft.AspNetCore.Mvc;
using AppProduct.Shared;
using AppProduct.Models;

namespace AppProduct.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public ActionResult Products()
        {
            var prod = SeedData.ProductsRepo.Read();
            var products = new List<ProductModel>();
            prod.ForEach(e => products.Add(e as ProductModel));
            return View(products);
        }
    }
}
