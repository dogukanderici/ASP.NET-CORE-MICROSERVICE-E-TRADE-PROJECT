namespace MultiShop.WebUI.Services.StatisticsServices.UserStatisticsServices
{
    public interface IUserStatisticsService
    {
        Task<int> GetUserCount();
    }
}
