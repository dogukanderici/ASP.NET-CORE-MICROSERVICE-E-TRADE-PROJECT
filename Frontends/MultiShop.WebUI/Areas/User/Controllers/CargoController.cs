using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class CargoController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
