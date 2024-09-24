using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.StatisticsServices.CatalogStatisticsServices;
using MultiShop.WebUI.Services.StatisticsServices.CommentStatisticsServices;
using MultiShop.WebUI.Services.StatisticsServices.DiscountStatisticsServices;
using MultiShop.WebUI.Services.StatisticsServices.MessageStatisticsServices;
using MultiShop.WebUI.Services.StatisticsServices.UserStatisticsServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Statistics")]
    public class StatisticsController : BaseController
    {
        private readonly ICatalogStatisticsService _catalogStatisticsService;
        private readonly IUserStatisticsService _userStatisticsService;
        private readonly ICommentStatisticsService _commentStatisticsService;
        private readonly IDiscountStatisticsService _discountStatisticsService;
        private readonly IMessageStatisticsService _messagestatisticsService;

        public StatisticsController(ICatalogStatisticsService catalogStatisticsService, IUserStatisticsService userStatisticsService, ICommentStatisticsService commentStatisticsService, IDiscountStatisticsService discountStatisticsService, IMessageStatisticsService messagestatisticsService)
        {
            _catalogStatisticsService = catalogStatisticsService;
            _userStatisticsService = userStatisticsService;
            _commentStatisticsService = commentStatisticsService;
            _discountStatisticsService = discountStatisticsService;
            _messagestatisticsService = messagestatisticsService;
        }

        public async Task<IActionResult> Index()
        {
            var brandCount = await _catalogStatisticsService.GetVendorCount();
            var categoryCount = await _catalogStatisticsService.GetCategoryCount();
            var productCount = await _catalogStatisticsService.GetProductCount();
            var maxPriceProductname = await _catalogStatisticsService.GetMaxPriceProductName();
            var minPriceproductName = await _catalogStatisticsService.GetMinPriceProductName();

            var userCount = await _userStatisticsService.GetUserCount();

            var activeCommentCount = await _commentStatisticsService.GetActiveCommentCount();
            var pasiveCommentCount = await _commentStatisticsService.GetPasiveCommentCount();
            var totalCommentCount = await _commentStatisticsService.GetTotalCommentCount();

            var discountCouponCount = await _discountStatisticsService.GetDiscountCouponCount();

            var messageCount = await _messagestatisticsService.GetTotalMessageCount();

            ViewBag.BrandCount = brandCount;
            ViewBag.CategoryCount = categoryCount;
            ViewBag.ProductCount = productCount;
            ViewBag.MaxPriceProductName = maxPriceProductname;
            ViewBag.MinPriceProductName = minPriceproductName;

            ViewBag.UserCount = userCount;

            ViewBag.ActiveCommentCount = activeCommentCount;
            ViewBag.PasiveCommentCount = pasiveCommentCount;
            ViewBag.TotalCommentCount = totalCommentCount;

            ViewBag.DiscountCouponCount = discountCouponCount;

            ViewBag.MessageCount = messageCount;

            return View();
        }
    }
}
