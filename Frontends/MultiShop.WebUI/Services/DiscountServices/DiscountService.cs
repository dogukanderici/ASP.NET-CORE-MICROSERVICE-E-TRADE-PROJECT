using MultiShop.Dtos.DiscountDtos;
using System.Net;
using System.Reflection.Emit;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountDetailByCode> GetDiscountCode(string code)
        {
            var responseMessage = await _httpClient.GetAsync("discounts/getcodedetailbycode?code=" + code);

            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                var value = await responseMessage.Content.ReadFromJsonAsync<GetDiscountDetailByCode>();

                return value;
            }

            return new GetDiscountDetailByCode
            {
                Code = "InvalidCode",
                CouponId = 0,
                IsActive = true,
                Rate = 0,
                ValidDate = DateTime.Now
            };
        }
    }
}
