﻿namespace MultiShop.Catalog.Dtos.VendorDtos
{
    public class UpdateVendorDto
    {
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
