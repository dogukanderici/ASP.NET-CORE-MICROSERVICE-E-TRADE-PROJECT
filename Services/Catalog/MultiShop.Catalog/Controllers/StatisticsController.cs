using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticsServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        [Route("GetBrandCount")]
        public IActionResult GetBrandCount()
        {
            var value = _statisticsService.GetVendorCount();

            return Ok(value);
        }

        [HttpGet]
        [Route("GetCategoryCount")]
        public IActionResult GetCategoryCount()
        {
            var value = _statisticsService.GetCategoryCount();

            return Ok(value);
        }

        [HttpGet]
        [Route("GetProductCount")]
        public IActionResult GetProductCount()
        {
            var value = _statisticsService.GetProductCount();

            return Ok(value);
        }

        [HttpGet]
        [Route("GetProductAvgPrice")]
        public IActionResult GetProductAvgPrice()
        {
            var value = _statisticsService.GetProductAvgPrice();

            return Ok(value);
        }
    }
}
