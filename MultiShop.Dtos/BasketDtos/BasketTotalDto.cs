using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Dtos.BasketDtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountRate { get; set; }
        public bool IsAppliedDiscount { get; set; } = false;
        public string CargoCompany { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
