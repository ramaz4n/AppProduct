using AppProduct.Models;
using AppProduct.Shared;
using AppProduct.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppProduct.Web.Controllers
{
    public class QueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Query()
        {
            return View();
        }
    }
}
