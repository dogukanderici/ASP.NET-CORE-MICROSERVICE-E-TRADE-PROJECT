using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services;
using System.Security.Claims;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}