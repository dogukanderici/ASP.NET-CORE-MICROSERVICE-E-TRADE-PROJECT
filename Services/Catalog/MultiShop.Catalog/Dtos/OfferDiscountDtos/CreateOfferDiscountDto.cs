namespace MultiShop.Catalog.Dtos.OfferDiscountDtos
{
    public class CreateOfferDiscountDto
    {
        public string OfferDiscountTitle { get; set; }
        public string OfferDiscountSubTitle { get; set; }
        public string OfferDiscountSubImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
