using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Directory1 = "MultiShop";
            ViewBag.Directory2 = "Ödeme Ekranı";
            ViewBag.Directory3 = "Kredi/Banka Kartı";

            return View();
        }
    }
}
