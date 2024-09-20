using MultiShop.Dtos.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        //Task<List<ResultMessageDto>> GetMessagesAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string receiverId);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string senderId);
        //Task CreateMessageAsync(CreateMessageDto createMessageDto);
        //void UpdateMessage(UpdateMessageDto updateMessageDto);
        //Task DeleteMessageAsync(int userMessageId);
        //Task<GetByIdMessageDto> GetByIdMessageAsync(int userMessageId);
    }
}
