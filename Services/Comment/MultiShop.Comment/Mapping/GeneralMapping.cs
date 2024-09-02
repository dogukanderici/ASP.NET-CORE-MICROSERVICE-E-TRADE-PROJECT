using AutoMapper;
using MultiShop.Comment.Dtos;
using MultiShop.Comment.Entities.Concrete;

namespace MultiShop.Comment.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserComment, ResultCommentDto>().ReverseMap();
            CreateMap<UserComment, GetByIdCommentDto>().ReverseMap();
            CreateMap<UserComment, CreateCommentDto>().ReverseMap();
            CreateMap<UserComment, UpdateCommentDto>().ReverseMap();
        }
    }
}
