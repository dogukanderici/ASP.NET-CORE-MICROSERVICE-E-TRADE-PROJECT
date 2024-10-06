using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MultiShop.Dtos.BasketDtos;
using MultiShop.Dtos.OrderDtos.OrderDetailDtos;
using MultiShop.Dtos.OrderDtos.OrderingDtos;
using Org.BouncyCastle.Crypto.Operators;

namespace MultiShop.WebUI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<BasketTotalDto, CreateOrderingDto>().ReverseMap();
            CreateMap<BasketItemDto, CreateOrderDetailDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.ProductAmount, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Price))
                .ReverseMap();

            CreateMap<BasketTotalDto, CreateOrderDetailDto>()
                .ForMember(dest => dest.ProductTotalPrice, opt => opt.MapFrom(src => src.TotalPrice));
        }
    }
}
