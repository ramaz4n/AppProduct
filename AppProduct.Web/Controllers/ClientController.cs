using AppProduct.Models;
using AppProduct.Shared;
using AppProduct.Shared.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;

namespace AppProduct.Web.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        { 
            return View();
        }
        public ActionResult Clients()
        {
            var ent = SeedData.ClientsRepo.Read();
            var clients = new List<ClientModel>();
            ent.ForEach(e => clients.Add(e as ClientModel));
            return View(clients);
        }
    }
}
