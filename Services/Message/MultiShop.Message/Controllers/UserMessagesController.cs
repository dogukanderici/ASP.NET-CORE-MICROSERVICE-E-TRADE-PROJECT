using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var values = await _userMessageService.GetMessagesAsync();

            return Ok(values);
        }

        [HttpGet]
        [Route("GetByIdMessage/{userMessageId}")]
        public async Task<IActionResult> GetByIdMessage(int userMessageId)
        {
            var value = await _userMessageService.GetByIdMessageAsync(userMessageId);

            return Ok(value);
        }

        [HttpGet]
        [Route("GetInboxMessage/{receiverId}")]
        public async Task<IActionResult> GetInboxMessage(string receiverId)
        {
            var value = await _userMessageService.GetInboxMessageAsync(receiverId);

            return Ok(value);
        }

        [HttpGet]
        [Route("GetSendboxMessage/{senderId}")]
        public async Task<IActionResult> GetSendboxMessage(string senderId)
        {
            var value = await _userMessageService.GetSendboxMessageAsync(senderId);

            return Ok(value);
        }

        [HttpGet]
        [Route("TotalMessageCount")]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            var value = await _userMessageService.GetTotalMessageCount();

            return Ok(value);
        }

        [HttpGet]
        [Route("TotalMessageCountByReceiverId")]
        public async Task<IActionResult> GetTotalMessageCountByReceiverId(string id)
        {
            var value = await _userMessageService.GetTotalMessageCountByReceiverId(id);

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);

            return Ok("Mesaj Başarıyla Gönderildi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int userMessageId)
        {
            await _userMessageService.DeleteMessageAsync(userMessageId);

            return Ok("Mesaj Başarıyla Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            _userMessageService.UpdateMessage(updateMessageDto);

            return Ok("Mesaj Başarıyla Güncellendi.");
        }
    }
}
