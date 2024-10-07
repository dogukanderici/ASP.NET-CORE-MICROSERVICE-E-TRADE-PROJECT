using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailsQueries
{
    public class GetOrderDetailByIdQuery
    {
        public int Id { get; set; }
        public Guid OrderingId { get; set; }

        public GetOrderDetailByIdQuery(Guid orderingId)
        {
            OrderingId = orderingId;
        }

        public GetOrderDetailByIdQuery(int id)
        {
            Id = id;
        }
    }
}
