﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.CargoDtos.CargoDetailDtos
{
    public class UpdateCargoDetailDto
    {
        public int CargoDetailId { get; set; }
        public string SenderCustomer { get; set; }
        public string RecieverCustomer { get; set; }
        public Guid Barcode { get; set; }
        public int CargoCompanyId { get; set; }
    }
}
