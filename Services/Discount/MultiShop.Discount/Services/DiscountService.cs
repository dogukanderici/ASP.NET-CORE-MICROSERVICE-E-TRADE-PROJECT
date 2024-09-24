using Dapper;
using MultiShop.Discount.DataAccess.Concrete.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "insert into Coupones(Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";

            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteDiscountCouponAsync(int couponId)
        {
            string query = "Delete From Coupones Where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "Select * From Coupones";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);

                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int couponId)
        {
            string query = "Select * From Coupones Where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);

                return value;
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetCodeDetailByCodeAsync(string code)
        {
            string query = "Select * From Coupones Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);

                return value;
            }
        }

        public async Task<int> GetDiscountCouponCount()
        {
            string query = "Select Count(*) From Coupones";

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<int>(query);

                return value;
            }
        }

        public async Task<int> GetDiscountCouponCountRate(string code)
        {
            string query = "Select Rate From Coupones Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query, parameters);

                return values;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "Update Coupones Set Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate Where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", updateCouponDto.CouponId);
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
