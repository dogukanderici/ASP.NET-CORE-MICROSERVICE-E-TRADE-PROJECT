using MultiShop.Dtos.BasketDtos;

namespace MultiShop.WebUI.Models
{
    public class OrderMailViewModel
    {
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice { get; set; }
        public string Address { get; set; }
        public UserDetailViewModel UserInfo { get; set; }
    }
}
