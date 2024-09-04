using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountsController : ControllerBase
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountsController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        [HttpGet]
        public async Task<IActionResult> OfferDiscountList()
        {
            var values = await _offerDiscountService.GetAllDataAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOfferDiscount(string id)
        {
            var value = await _offerDiscountService.GetDataAsync(id);

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateDataAsync(createOfferDiscountDto);

            return Ok("Özel İndirim Başarıyla Eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateDataAsync(updateOfferDiscountDto);

            return Ok("Özel İndirim Başarıyla Güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOfferDicount(string id)
        {
            await _offerDiscountService.DeleteDataAsync(id);

            return Ok("Özel İndirim Başarıyla Silindi.");
        }
    }
}
