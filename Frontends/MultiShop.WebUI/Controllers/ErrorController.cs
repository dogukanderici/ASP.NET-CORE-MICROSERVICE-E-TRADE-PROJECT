using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound404()
        {
            return View();
        }

        public IActionResult Unauthorized401()
        {
            return View();
        }

        public IActionResult BadRequest500()
        {
            return View();
        }

        public IActionResult InvalidPage()
        {
            return View();
        }
    }
}
