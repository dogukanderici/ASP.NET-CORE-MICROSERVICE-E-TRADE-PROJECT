namespace MultiShop.Basket.Dtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int DiscountRate { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return (BasketItems != null && BasketItems.Any())
                    ? BasketItems.Where(x => x != null).Sum(x => x.Price * x.Quantity)
                    : 0;
            }
        }
    }
}
