using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.CatalogDtos.OfferDiscountDtos
{
    public class CreateOfferDiscountDto
    {
        public string OfferDiscountTitle { get; set; }
        public string OfferDiscountSubTitle { get; set; }
        public string OfferDiscountSubImageUrl { get; set; }
        public IFormFile OfferDiscountSubImage { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
