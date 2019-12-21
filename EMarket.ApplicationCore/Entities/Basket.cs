using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMarket.ApplicationCore.Entities
{
    public class Basket
    {
        private readonly List<BasketItem> _items = new List<BasketItem>();

        public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();

        public void AddItem(int productId, decimal unitPrice, string imagePath, int quantity = 1)
        {
            if (!Items.Any(x => x.ProductId == productId))
            {
                _items.Add(new BasketItem
                {
                    ProductId = productId,
                    UnitPrice = unitPrice,
                    ImagePath = imagePath,
                    Quantity = quantity
                });
                return;
            }

            var existingItem = Items.FirstOrDefault(x => x.ProductId == productId);
            existingItem.Quantity += quantity;
        }

        public void RemoveEmptyItems()
        {
            _items.RemoveAll(x => x.Quantity == 0);
        }
    }
}
