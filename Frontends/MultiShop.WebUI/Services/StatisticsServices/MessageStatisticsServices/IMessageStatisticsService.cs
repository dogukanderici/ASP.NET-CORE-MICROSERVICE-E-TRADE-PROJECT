namespace MultiShop.WebUI.Services.StatisticsServices.MessageStatisticsServices
{
    public interface IMessageStatisticsService
    {
        Task<int> GetTotalMessageCount();
    }
}
