﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await _discountService.GetAllDiscountCouponAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var value = await _discountService.GetByIdDiscountCouponAsync(id);

            return Ok(value);
        }

        [HttpGet]
        [Route("GetCodeDetailByCode")]
        public async Task<IActionResult> GetCodeDetailByCode(string code)
        {
            var value = await _discountService.GetCodeDetailByCodeAsync(code);

            return Ok(value);
        }

        [HttpGet]
        [Route("GetDiscountCouponCountRate")]
        public async Task<IActionResult> GetDiscountCouponCountRate(string code)
        {
            var value = await _discountService.GetDiscountCouponCountRate(code);

            return Ok(value);
        }

        [HttpGet]
        [Route("GetDiscountCouponCount")]
        public async Task<IActionResult> GetDiscountCouponCount()
        {
            var value = await _discountService.GetDiscountCouponCount();

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createDiscountCouponDto)
        {
            await _discountService.CreateDiscountCouponAsync(createDiscountCouponDto);

            return Ok("Yeni İndirim Kupon Oluşturuldu.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);

            return Ok("İndirim Kuponu Başarıyla Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountDiscountCoupon(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            await _discountService.UpdateDiscountCouponAsync(updateDiscountCouponDto);

            return Ok("İndirim Kuponu Başarıyla Güncelledi.");
        }
    }
}
