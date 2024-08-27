namespace MultiShop.Catalog.Dtos.SpecialOfferDtos
{
    public class CreateSpecialOfferDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        //public IFormFile Image {  get; set; }
        public bool IsActive { get; set; }
    }
}
