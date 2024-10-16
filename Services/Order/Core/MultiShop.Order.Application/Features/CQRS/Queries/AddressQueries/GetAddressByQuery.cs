﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByQuery
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public GetAddressByQuery(string userId)
        {
            UserId = userId;
        }

        public GetAddressByQuery(Guid id)
        {
            Id = id;
        }
    }
}
