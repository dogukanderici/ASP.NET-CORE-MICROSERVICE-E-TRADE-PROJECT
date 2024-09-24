using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto);
        Task DeleteDiscountCouponAsync(int couponId);
        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int couponId);
        Task<GetByIdDiscountCouponDto> GetCodeDetailByCodeAsync(string code);
        Task<int> GetDiscountCouponCountRate(string code);
        Task<int> GetDiscountCouponCount();
    }
}
