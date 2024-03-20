using AppProduct.Models;
using AppProduct.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AppProduct.Web.Controllers
{
    public class CheapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Cheap()
        {
            var products = SeedData.ProductsRepo.Read();
            var ent1 = new List<ProductModel>();
            products.ForEach(e => ent1.Add(e as ProductModel));

            var prices = SeedData.PriceRatesRepo.Read();
            var ent2 = new List<PriceRate>();
            prices.ForEach(e => ent2.Add(e as PriceRate));

            double min = 100000.0;

            foreach (var i in ent2)
                if (Convert.ToDouble(i.Value) < min) min = Convert.ToDouble(i.Value);

            var result = new List<ProductModel>();

            foreach (var i in ent2)
            {
                if (Convert.ToDouble(i.Value) == min)
                {
                    foreach (var j in ent1)
                        if (j.Id == i.ProductId) result.Add(j);
                };

            }
            return View(result);

        }
    }
}
