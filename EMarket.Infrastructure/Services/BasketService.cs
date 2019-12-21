using EMarket.ApplicationCore.Entities;
using EMarket.ApplicationCore.Interfaces;
using EMarket.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMarket.Infrastructure.Services
{
    public class BasketService : IBasketService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _basket = httpContextAccessor.HttpContext.Session.Get<Basket>("basket") ?? new Basket();
        }

        private Basket _basket;
        public Basket Basket => _basket;

        public void AddItemToBasket(int productId, decimal unitPrice, string imagePath, int quantity = 1)
        {
            _basket.AddItem(productId, unitPrice, imagePath, quantity);
        }

        public void EmptyBasket()
        {
            _basket = new Basket();
            SaveBasket();
        }

        public int GetBasketItemCount()
        {
            return _basket.Items.Sum(x => x.Quantity);
        }

        public void RemoveItemFromBasket(int productId)
        {
            _basket.Items.FirstOrDefault(x => x.ProductId == productId).Quantity = 0;
            _basket.RemoveEmptyItems();
        }

        private void SaveBasket()
        {
            _httpContextAccessor.HttpContext.Session.Set("basket", _basket);
        }
    }
}
