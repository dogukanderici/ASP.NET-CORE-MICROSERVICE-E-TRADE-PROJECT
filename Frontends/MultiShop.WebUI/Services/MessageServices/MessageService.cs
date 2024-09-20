using MultiShop.Dtos.MessageDtos;
using NuGet.Protocol.Plugins;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string receiverId)
        {
            var response = await _httpClient.GetAsync("usermessages/getinboxmessage/" + receiverId);
            var values = await response.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();

            return values;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string senderId)
        {
            var response = await _httpClient.GetAsync("usermessages/getsendboxmessage/" + senderId);
            var values = await response.Content.ReadFromJsonAsync<List<ResultSendboxMessageDto>>();

            return values;
        }
    }
}
