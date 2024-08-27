namespace MultiShop.Catalog.Dtos.ServiceStandardDtos
{
    public class UpdateServiceStandardDto
    {
        public string ServiceStandardId { get; set; }
        public string ServiceStandardName { get; set; }
        public string ServiceStandardIcon { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
