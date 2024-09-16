using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.VendorDtos;
using MultiShop.WebUI.Services.CatalogServices.VendorServices;
using MultiShop.WebUI.Utilities.AuthTokenOperations;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        private readonly IVendorService _vendorService;

        public _VendorDefaultComponentPartial(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var requestMessage = await _vendorService.GetAllDataAsync();

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return View();
        }
    }
}
