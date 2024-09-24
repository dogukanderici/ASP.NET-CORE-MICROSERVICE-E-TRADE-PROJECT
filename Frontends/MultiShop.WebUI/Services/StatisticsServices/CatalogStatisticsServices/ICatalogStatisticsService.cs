namespace MultiShop.WebUI.Services.StatisticsServices.CatalogStatisticsServices
{
    public interface ICatalogStatisticsService
    {
        Task<long> GetCategoryCount();
        Task<long> GetProductCount();
        Task<long> GetVendorCount();
        Task<decimal> GetProductAvgPrice();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}
