using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            var user = User.Claims;

            return View();
        }
    }
}
