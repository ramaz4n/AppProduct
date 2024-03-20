using Microsoft.AspNetCore.Mvc;
using AppProduct.Models;
using AppProduct.Shared;

namespace AppProduct.Web.Controllers
{
    public class OldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Olds()
        {
            var ent = SeedData.ClientsRepo.Read();
            var clients = new List<ClientModel>();
            ent.ForEach(e => clients.Add(e as ClientModel));
            int max = 0;
            var result = new List<ClientModel>();
            foreach (var i in clients)
            {
                if (i.Age > max) max = i.Age;
            };
            foreach (var i in clients)
                if (i.Age == max)
                    result.Add(i);
            return View(result);
        }
    }

}
    

