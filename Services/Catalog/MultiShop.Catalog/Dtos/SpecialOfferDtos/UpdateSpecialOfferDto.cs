namespace MultiShop.Catalog.Dtos.SpecialOfferDtos
{
    public class UpdateSpecialOfferDto
    {
        public string SpecailOfferId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        //public IFormFile Image { get; set; }
        public bool IsActive { get; set; }
    }
}
