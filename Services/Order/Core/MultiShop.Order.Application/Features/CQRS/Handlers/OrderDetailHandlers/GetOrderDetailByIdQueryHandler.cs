using AutoMapper;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailsQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailsResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdOrderDetailQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var value = await _repository.GetByFilterAsync(od => od.OrderDetailId == query.Id);

            var valueToDto = _mapper.Map<GetByIdOrderDetailQueryResult>(value);

            return valueToDto;
        }
    }
}
