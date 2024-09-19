using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DataAccess.Concrete.Context;
using MultiShop.Message.Dtos;
using MultiShop.Message.Entities;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var valueFromDto = _mapper.Map<UserMessage>(createMessageDto);

            await _messageContext.UserMessages.AddAsync(valueFromDto);
            await _messageContext.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int userMessageId)
        {
            var values = await _messageContext.UserMessages.FindAsync(userMessageId);

            if (values != null)
            {
                var valueFromDto = _mapper.Map<UserMessage>(values);

                _messageContext.UserMessages.Remove(valueFromDto);
                await _messageContext.SaveChangesAsync();
            }
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int userMessageId)
        {
            var value = await _messageContext.UserMessages.Where(x => x.UserMessageId == userMessageId).SingleOrDefaultAsync();
            var valueToDto = _mapper.Map<GetByIdMessageDto>(value);

            return valueToDto;
        }

        public async Task<List<ResultMessageDto>> GetInboxMessageAsync(string receiverId)
        {
            var values = await _messageContext.UserMessages.Where(x => x.ReceiverId == receiverId).ToListAsync();

            return values.Select(x => _mapper.Map<ResultMessageDto>(x)).ToList();
        }

        public async Task<List<ResultMessageDto>> GetMessagesAsync()
        {
            var value = await _messageContext.UserMessages.ToListAsync();

            return value.Select(x => _mapper.Map<ResultMessageDto>(x)).ToList();
        }

        public async Task<List<ResultMessageDto>> GetSendboxMessageAsync(string senderId)
        {
            var values = await _messageContext.UserMessages.Where(x => x.SenderId == senderId).ToListAsync();

            return values.Select(x => _mapper.Map<ResultMessageDto>(x)).ToList();
        }

        public void UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var valueFromDto = _mapper.Map<UserMessage>(updateMessageDto);

            _messageContext.UserMessages.Update(valueFromDto);
            _messageContext.SaveChanges();
        }
    }
}
