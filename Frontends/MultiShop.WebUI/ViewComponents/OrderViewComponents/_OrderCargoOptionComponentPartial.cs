using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderCargoOptionComponentPartial : ViewComponent
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public _OrderCargoOptionComponentPartial(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _cargoCompanyService.TGetAllAsync(null);

            List<SelectListItem> cargoCompanies = (from x in values
                                                   select
                                                   new SelectListItem
                                                   {
                                                       Text = x.CargoCompanyName,
                                                       Value = Convert.ToString(x.CargoCompanyId)
                                                   }).ToList();

            cargoCompanies.Insert(0, new SelectListItem
            {
                Text = "Kargo Şirketi Seçiniz",
                Value = "",
                Selected = true
            });

            ViewBag.CargoCompanies = cargoCompanies;

            return View();
        }
    }
}
