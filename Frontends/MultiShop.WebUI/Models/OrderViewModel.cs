using MultiShop.Dtos.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Models
{
    public class OrderViewModel
    {
        public UpdateOrderAddressDto UpdateOrderAddress { get; set; }
        public string SelectedCargoCompany { get; set; }
    }
}
