﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetOrderingQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(Guid id)
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(id));

            return Ok(value);
        }

        [HttpGet]
        [Route("GetOrderingByUserId")]
        public async Task<IActionResult> GetOrderingByUserId(string userId)
        {
            var values = await _mediator.Send(new GetOrderingByUserIdQuery(userId));

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand createOrderingCommand)
        {
            await _mediator.Send(createOrderingCommand);

            return Ok("Sipariş Başarıyla Eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(Guid id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));

            return Ok("Sipariş Başarıyla Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand updateOrderingCommand)
        {
            await _mediator.Send(updateOrderingCommand);

            return Ok("Sipariş Başarıyla Güncellendi.");
        }
    }
}
