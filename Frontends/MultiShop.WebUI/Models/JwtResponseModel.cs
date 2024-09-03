namespace MultiShop.WebUI.Models
{
    public class JwtResponseModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
