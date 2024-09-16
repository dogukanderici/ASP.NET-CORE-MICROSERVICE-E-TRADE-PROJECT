using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services;
using System.Security.Claims;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Directory1 = "MultiShop";
            ViewBag.Directory2 = "Ürünler";
            ViewBag.Directory3 = "Ürün Listesi";

            return View();
        }
    }
}