﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.OrderDtos.OrderAddressDtos
{
    public class UpdateOrderAddressDto
    {
        public Guid AddressId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Discrict { get; set; }
        public string City { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
        public string Description { get; set; }
        public string ZipCode { get; set; }
    }
}
