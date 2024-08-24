using AutoMapper;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailsResults;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Address, GetAddressQueryResult>().ReverseMap();
            CreateMap<Address, GetAddressByIdQueryResult>().ReverseMap();
            CreateMap<Address, CreateAddressCommand>().ReverseMap();
            CreateMap<Address, UpdateAddressCommand>().ReverseMap();

            CreateMap<Ordering, GetOrderingQueryResult>().ReverseMap();
            CreateMap<Ordering, GetOrderingByIdQueryResult>().ReverseMap();
            CreateMap<Ordering, CreateOrderingCommand>().ReverseMap();
            CreateMap<Ordering, UpdateOrderingCommand>().ReverseMap();

            CreateMap<OrderDetail, GetByIdOrderDetailQueryResult>().ReverseMap();
            CreateMap<OrderDetail, GetOrderDetailQueryResult>().ReverseMap();
            CreateMap<OrderDetail, CreateOrderDetailCommand>().ReverseMap();
            CreateMap<OrderDetail, UpdateOrderDetailCommand>().ReverseMap();



        }
    }
}
