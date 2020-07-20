using System;
using System.Collections.Generic;
using System.Linq;
using Teksystems.Core.Models;
using Teksystems.Core.Services;

namespace Teksystems.Services
{
    public class ReceiptCalculator : IReceiptCalculator
    {
        private readonly IItemsRepository itemsRepository;
        private readonly ITaxCalculator taxCalculator;

        public ReceiptCalculator(IItemsRepository itemsRepository, ITaxCalculator taxCalculator)
        {
            this.itemsRepository = itemsRepository;
            this.taxCalculator = taxCalculator;
        }

        public Receipt Calculate(ShoppingCart cart)
        {
            if(cart.Items.Count == 0)
            {
                throw new InvalidOperationException("Cannot create a receipt for an empty cart.");
            }

            var receiptEntries = new List<ReceiptEntry>(cart.Items.Count);
            foreach (var cartItem in cart.Items)
            {
                var item = this.itemsRepository.GetById(cartItem.ItemId);
                var costPerItem = this.taxCalculator.CalculateTax(item, cartItem.Count);
                var entry = new ReceiptEntry(item, cartItem.Count, item.Price * cartItem.Count, costPerItem * cartItem.Count);
                receiptEntries.Add(entry);
            }

            var subtotal = receiptEntries.Sum(x => x.Subtotal);
            var total = receiptEntries.Sum(x => x.Total);
            return new Receipt(receiptEntries.AsReadOnly(), subtotal, total);
        }
    }
}
