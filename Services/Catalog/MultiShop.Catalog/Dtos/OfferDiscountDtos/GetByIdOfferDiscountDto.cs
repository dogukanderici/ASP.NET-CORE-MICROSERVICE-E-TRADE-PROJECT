namespace MultiShop.Catalog.Dtos.OfferDiscountDtos
{
    public class GetByIdOfferDiscountDto
    {
        public string OfferDiscountId { get; set; }
        public string OfferDiscountTitle { get; set; }
        public string OfferDiscountSubTitle { get; set; }
        public string OfferDiscountSubImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
