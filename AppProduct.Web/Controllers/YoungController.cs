using AppProduct.Models;
using AppProduct.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace AppProduct.Web.Controllers
{
    public class YoungController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Youngs()
        {
            var ent = SeedData.ClientsRepo.Read();
            var clients = new List<ClientModel>();
            ent.ForEach(e => clients.Add(e as ClientModel));
            int min = 200;
            var result = new List<ClientModel>();
            foreach (var i in clients) 
            {
                if (i.Age < min) min = i.Age;
            };
            foreach (var i in clients)
                if (i.Age == min)
                    result.Add(i);
            return View(result);
        }
    }
}
