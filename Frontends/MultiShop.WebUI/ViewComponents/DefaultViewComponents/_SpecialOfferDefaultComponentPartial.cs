using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecailOfferServies;
using MultiShop.WebUI.Utilities.AuthTokenOperations;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferDefaultComponentPartial : ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

        public _SpecialOfferDefaultComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var requestMessage = await _specialOfferService.GetAllDataAsync();

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return View();
        }
    }
}
