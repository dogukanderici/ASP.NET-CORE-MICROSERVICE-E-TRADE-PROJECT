namespace MultiShop.Basket.Dtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountRate { get; set; }
        public bool IsAppliedDiscount { get; set; } = false;
        public List<BasketItemDto> BasketItems { get; set; }
        //public decimal TotalPrice
        //{
        //    get
        //    {
        //        return (BasketItems != null && BasketItems.Any())
        //            ? BasketItems.Where(x => x != null).Sum(x => x.TotalItemPrice * ((100 + Tax) / 100))
        //            : 0;
        //    }
        //}
        public decimal TotalPrice { get; set; }
    }
}
