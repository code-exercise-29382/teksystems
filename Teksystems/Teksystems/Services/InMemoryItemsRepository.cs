using System;
using System.Collections.Generic;
using Teksystems.Core.Models;
using Teksystems.Core.Services;
using Teksystems.Utils;

namespace Teksystems.Services
{
    public class InMemoryItemsRepository : IItemsRepository
    {
        private static readonly IDictionary<Guid, Item> AllItems = new Dictionary<Guid, Item>
        {
            { ItemIds.Input1_Book, new Item("Book", 12.49m, SalesTaxModifier.ExemptFromBasicTax) },
            { ItemIds.Input1_ChocolateBar, new Item("Chocolate bar", 0.85m, SalesTaxModifier.ExemptFromBasicTax) },
            { ItemIds.Input1_MusicCD, new Item("Music CD", 14.99m) },

            { ItemIds.Input2_ImportedBottleOfPerfume, new Item("Bottle of perfume", 47.50m, SalesTaxModifier.Imported) },
            { ItemIds.Input2_ImportedBoxOfChocolate, new Item("Box of chocolate", 10m, SalesTaxModifier.Imported) },

            { ItemIds.Input3_ImportedBottleOfPerfume, new Item("Bottle of perfume", 32.19m, SalesTaxModifier.Imported) },
            { ItemIds.Input3_HeadachePills, new Item("Packet of headache pills", 9.75m, SalesTaxModifier.ExemptFromBasicTax) },
            { ItemIds.Input3_BottleOfPerfume, new Item("Bottle of perfume", 20.89m) },
            { ItemIds.Input3_ImportedChocolates, new Item("Box of chocolates", 11.85m, SalesTaxModifier.Imported | SalesTaxModifier.ExemptFromBasicTax) },
        };

        public Item GetById(Guid itemId)
        {
            if(AllItems.TryGetValue(itemId, out var item))
            {
                return item;
            }

            throw new InvalidOperationException("Item does not exist.");
        }
    }
}
