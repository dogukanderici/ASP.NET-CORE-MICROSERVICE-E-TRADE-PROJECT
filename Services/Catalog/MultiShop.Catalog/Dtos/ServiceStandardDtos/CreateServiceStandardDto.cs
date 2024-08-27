namespace MultiShop.Catalog.Dtos.ServiceStandardDtos
{
    public class CreateServiceStandardDto
    {
        public string ServiceStandardName { get; set; }
        public string ServiceStandardIcon { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
