namespace MultiShop.WebUI.Services.StatisticsServices.CommentStatisticsServices
{
    public interface ICommentStatisticsService
    {
        Task<int> GetActiveCommentCount();
        Task<int> GetPasiveCommentCount();
        Task<int> GetTotalCommentCount();
    }
}
