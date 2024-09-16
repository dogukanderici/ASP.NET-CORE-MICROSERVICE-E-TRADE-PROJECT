using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MultiShop.Dtos.CatalogDtos.ServiceStandardDtos;
using MultiShop.WebUI.Services.CatalogServices.ServiceStandardServices;
using MultiShop.WebUI.Utilities.AuthTokenOperations;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
        private readonly IServiceStandardService _serviceStandardService;

        public _FeatureDefaultComponentPartial(IServiceStandardService serviceStandardService)
        {
            _serviceStandardService = serviceStandardService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var requestMessage = await _serviceStandardService.GetAllDataAsync();

            if (requestMessage != null)
            {
                return View(requestMessage);
            }

            return View();
        }
    }
}
