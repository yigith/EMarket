using EMarket.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMarket.ApplicationCore.Interfaces
{
    public interface IBasketService
    {
        Basket Basket { get;  }
        int GetBasketItemCount();
        void AddItemToBasket(int productId, decimal unitPrice, string imagePath, int quantity = 1);
        void RemoveItemFromBasket(int productId);
        void EmptyBasket();
    }
}
