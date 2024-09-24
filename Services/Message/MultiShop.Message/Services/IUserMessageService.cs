using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetMessagesAsync();
        Task<List<ResultMessageDto>> GetInboxMessageAsync(string receiverId);
        Task<List<ResultMessageDto>> GetSendboxMessageAsync(string senderId);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        void UpdateMessage(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int userMessageId);
        Task<GetByIdMessageDto> GetByIdMessageAsync(int userMessageId);
        Task<int> GetTotalMessageCount();
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
