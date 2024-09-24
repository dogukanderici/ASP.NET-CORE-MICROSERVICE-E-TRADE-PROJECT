namespace MultiShop.WebUI.Services.StatisticsServices.DiscountStatisticsServices
{
    public interface IDiscountStatisticsService
    {
        Task<int> GetDiscountCouponCountRate(string code);
        Task<int> GetDiscountCouponCount();
    }
}
