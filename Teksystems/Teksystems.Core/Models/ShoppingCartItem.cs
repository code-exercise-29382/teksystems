using System;

namespace Teksystems.Core.Models
{
    public class ShoppingCartItem
    {
        public ShoppingCartItem(Guid itemId, int count)
        {
            ItemId = itemId;
            Count = count;
        }

        public Guid ItemId { get; }

        public int Count { get; }
    }
}
