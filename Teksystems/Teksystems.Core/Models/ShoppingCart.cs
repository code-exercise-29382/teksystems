using System;
using System.Collections.Generic;

namespace Teksystems.Core.Models
{
    public class ShoppingCart
    {
        private readonly List<ShoppingCartItem> items;

        public ShoppingCart()
        {
            this.items = new List<ShoppingCartItem>();
        }

        public IReadOnlyList<ShoppingCartItem> Items => this.items.AsReadOnly();

        public void Add(Guid itemId, int count)
        {
            this.items.Add(new ShoppingCartItem(itemId, count));
        }
    }
}
