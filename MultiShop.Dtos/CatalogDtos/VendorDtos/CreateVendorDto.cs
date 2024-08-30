using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.CatalogDtos.VendorDtos
{
    public class CreateVendorDto
    {
        public string VendorName { get; set; }
        public string VendorImageUrl { get; set; }
        public IFormFile VendorImage { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
