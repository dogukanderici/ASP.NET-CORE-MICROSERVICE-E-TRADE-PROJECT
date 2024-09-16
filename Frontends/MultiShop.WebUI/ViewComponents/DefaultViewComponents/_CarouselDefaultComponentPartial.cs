using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using MultiShop.WebUI.Utilities.AuthTokenOperations;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;

        public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var requestMessage = await _featureSliderService.GetAllDataAsync();

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return View();
        }
    }
}
