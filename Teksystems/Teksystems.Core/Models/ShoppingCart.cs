using System;
using System.Collections.Generic;
using System.Text;

namespace Teksystems.Core.Models
{
    public class ShoppingCart
    {
        private readonly List<Guid> _items;

        public ShoppingCart()
        {
            this._items = new List<Guid>();
        }

        public void Add(Guid itemId)
        {
            this._items.Add(itemId);
        }
    }
}
