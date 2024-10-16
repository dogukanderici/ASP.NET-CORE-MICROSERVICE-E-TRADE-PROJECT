﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Domain.Entities
{
    public class Ordering
    {
        public Guid OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDat { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
