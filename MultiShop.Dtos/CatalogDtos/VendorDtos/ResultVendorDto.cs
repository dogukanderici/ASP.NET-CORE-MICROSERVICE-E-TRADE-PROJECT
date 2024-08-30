using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.CatalogDtos.VendorDtos
{
    public class ResultVendorDto
    {
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
