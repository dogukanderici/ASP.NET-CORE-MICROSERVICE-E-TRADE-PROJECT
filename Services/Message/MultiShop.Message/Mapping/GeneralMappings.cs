using AutoMapper;
using MultiShop.Message.Dtos;
using MultiShop.Message.Entities;

namespace MultiShop.Message.Mapping
{
    public class GeneralMappings : Profile
    {
        public GeneralMappings()
        {
            CreateMap<UserMessage, ResultMessageDto>().ReverseMap();
            CreateMap<UserMessage, CreateMessageDto>().ReverseMap();
            CreateMap<UserMessage, UpdateMessageDto>().ReverseMap();
            CreateMap<UserMessage, GetByIdMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultInboxMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultSendboxMessageDto>().ReverseMap();
        }
    }
}
