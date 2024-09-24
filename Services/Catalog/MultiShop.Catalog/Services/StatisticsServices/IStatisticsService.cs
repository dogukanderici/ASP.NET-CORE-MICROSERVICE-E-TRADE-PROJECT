namespace MultiShop.Catalog.Services.StatisticsServices
{
    public interface IStatisticsService
    {
        long GetCategoryCount();
        long GetProductCount();
        long GetVendorCount();
        Task<decimal> GetProductAvgPrice();
        string GetMaxPriceProductName();
        string GetMinPriceProductName();
    }
}
