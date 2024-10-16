﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.Dtos.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            var response = await _httpClient.GetAsync("basket");
            var values = await response.Content.ReadFromJsonAsync<BasketTotalDto>();

            if (values.BasketItems != null)
            {
                values.TotalPrice = values.BasketItems.Sum(x => x.TotalItemPrice + (x.TotalItemPrice / 100 * x.Tax));
            }

            return values;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("basket", basketTotalDto);
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await GetBasket();

            if (values.BasketItems != null)
            {
                if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
                {
                    values.BasketItems.Add(basketItemDto);
                }
            }
            else
            {
                values.BasketItems = new List<BasketItemDto> { basketItemDto };
            }

            values = new BasketTotalDto
            {
                DiscountCode = "Yok",
                DiscountRate = 0,
                UserId = values.UserId,
                BasketItems = values.BasketItems,
                CargoCompany = "0"
            };

            values.TotalPrice = values.BasketItems.Sum(x => x.TotalItemPrice + (x.TotalItemPrice / 100 * x.Tax));

            await SaveBasket(values);
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            var result = values.BasketItems.Remove(deletedItem);

            await SaveBasket(values);

            return true;
        }

        public async Task<bool> DeleteBasket()
        {
            await _httpClient.DeleteAsync("basket");

            return true;
        }
    }
}
