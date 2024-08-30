namespace MultiShop.Catalog.Dtos.VendorDtos
{
    public class CreateVendorDto
    {
        public string VendorName { get; set; }
        public string VendorImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
