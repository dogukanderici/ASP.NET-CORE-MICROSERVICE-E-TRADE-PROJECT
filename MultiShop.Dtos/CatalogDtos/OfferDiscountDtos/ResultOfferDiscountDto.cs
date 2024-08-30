using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.CatalogDtos.OfferDiscountDtos
{
    public class ResultOfferDiscountDto
    {
        public string OfferDiscountId { get; set; }
        public string OfferDiscountTitle { get; set; }
        public string OfferDiscountSubTitle { get; set; }
        public string OfferDiscountSubImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
