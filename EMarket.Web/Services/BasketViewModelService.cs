using EMarket.ApplicationCore.Entities;
using EMarket.ApplicationCore.Interfaces;
using EMarket.Web.Interfaces;
using EMarket.Web.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMarket.Web.Services
{
    public class BasketViewModelService : IBasketViewModelService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IBasketService _basketService;

        public BasketViewModelService(IBasketService basketService, IRepository<Product> productRepository)
        {
            _basketService = basketService;
            _productRepository = productRepository;
        }

        public HeaderBasketViewModel AddItemToBasket(int productId)
        {
            var product = _productRepository.GetById(productId);
            _basketService.AddItemToBasket(product.Id, product.UnitPrice, product.ImagePath);

            return new HeaderBasketViewModel
            {
                TotalItems = _basketService.GetBasketItemCount(),
                HeaderBasketHtml = JsonConvert.SerializeObject(_basketService.Basket.Items)
            };
        }
    }
}
