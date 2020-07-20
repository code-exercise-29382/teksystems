using System;
using System.Collections.Generic;
using System.Linq;
using Teksystems.Core.Models;
using Teksystems.Core.Services;
using Teksystems.Utils;

namespace Teksystems.Services
{
    public class ReceiptCalculator : IReceiptCalculator
    {
        private readonly IItemsRepository itemsRepository;

        public ReceiptCalculator(IItemsRepository itemsRepository)
        {
            this.itemsRepository = itemsRepository;
        }

        public Receipt Calculate(ShoppingCart cart)
        {
            var receiptEntries = new List<ReceiptEntry>(cart.Items.Count);
            foreach (var cartItem in cart.Items)
            {
                var item = this.itemsRepository.GetById(cartItem.ItemId);
                var costPerItem = this.CalculateCostWithTaxes(item, cartItem.Count);
                var entry = new ReceiptEntry(item, cartItem.Count, item.Price * cartItem.Count, costPerItem * cartItem.Count);
                receiptEntries.Add(entry);
            }

            var subtotal = receiptEntries.Sum(x => x.Subtotal);
            var total = receiptEntries.Sum(x => x.Total);
            return new Receipt(receiptEntries.AsReadOnly(), subtotal, total);
        }

        private decimal CalculateCostWithTaxes(Item item, int count)
        {
            var total = item.Price;
            if(!item.IsExemptFromBasicSalesTax)
            {
                var basicSalesTax = RoundHelper.RoundToNearest((item.Price * count) * 0.1m, 0.05m);
                total += basicSalesTax;
            }

            if (item.IsImported)
            {
                var importTax = RoundHelper.RoundToNearest((item.Price * count) * 0.05m, 0.05m);
                total += importTax;
            }

            return total;
        }
    }
}
