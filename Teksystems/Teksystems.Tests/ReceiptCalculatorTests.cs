using System;
using System.Collections.Generic;
using Teksystems.Core.Models;
using Teksystems.Services;
using Teksystems.Tests.Mocks;
using Teksystems.Tests.Mocks.Services;
using Xunit;

namespace Teksystems.Tests
{
    public class ReceiptCalculatorTests
    {
        private ReceiptCalculator receiptCalculator;

        public ReceiptCalculatorTests()
        {
            this.receiptCalculator = new ReceiptCalculator(new InMemoryItemsRepository(), new TaxCalculator(0.1m, 0.05m));
        }

        public static IEnumerable<object[]> IndividualItemsSampleData
        {
            get
            {
                yield return new object[] { ItemIds.Input1_Book, 12.49m };
                yield return new object[] { ItemIds.Input1_ChocolateBar, 0.85m };
                yield return new object[] { ItemIds.Input1_MusicCD, 16.49m };

                yield return new object[] { ItemIds.Input2_ImportedBottleOfPerfume, 54.65m };
                yield return new object[] { ItemIds.Input2_ImportedBoxOfChocolate, 10.50m };

                yield return new object[] { ItemIds.Input3_BottleOfPerfume, 20.89m };
                yield return new object[] { ItemIds.Input3_HeadachePills, 9.75m };
                yield return new object[] { ItemIds.Input3_ImportedBottleOfPerfume, 32.19m };
                yield return new object[] { ItemIds.Input3_ImportedChocolates, 11.85m };
            }
        }

        public static IEnumerable<object[]> ShoppingCartSampleData
        {
            get
            {
                var cart1 = new ShoppingCart();
                cart1.Add(ItemIds.Input1_Book, 1);
                cart1.Add(ItemIds.Input1_ChocolateBar, 1);
                cart1.Add(ItemIds.Input1_MusicCD, 1);
                yield return new object[] { cart1, 1.50m, 29.83m };

                var cart2 = new ShoppingCart();
                cart2.Add(ItemIds.Input2_ImportedBottleOfPerfume, 1);
                cart2.Add(ItemIds.Input2_ImportedBoxOfChocolate, 1);
                yield return new object[] { cart2, 7.65m, 65.15m };

                var cart3 = new ShoppingCart();
                cart3.Add(ItemIds.Input3_BottleOfPerfume, 1);
                cart3.Add(ItemIds.Input3_HeadachePills, 1);
                cart3.Add(ItemIds.Input3_ImportedBottleOfPerfume, 1);
                cart3.Add(ItemIds.Input3_ImportedChocolates, 1);
                yield return new object[] { cart3, 6.70m, 74.68m };
            }
        }

        [Theory]
        [MemberData(nameof(IndividualItemsSampleData))]
        public void ReceiptCalcultor_WithSampleItems_CalculatesTaxesAndTotalCorrectly(Guid itemId, decimal expectedPrice)
        {
            var cart = new ShoppingCart();
            cart.Add(itemId, 1);

            var receipt = this.receiptCalculator.Calculate(cart);

            Assert.Equal(expectedPrice, receipt.Total);
        }

        [Theory]
        [MemberData(nameof(ShoppingCartSampleData))]
        public void ReceiptCalcultor_WithSampleShoppingCartData_CalculatesTaxesAndTotalCorrectly(ShoppingCart cart, decimal expectedTaxes, decimal expectedTotal)
        {
            var receipt = this.receiptCalculator.Calculate(cart);

            Assert.Equal(expectedTaxes, receipt.Taxes);
            Assert.Equal(expectedTotal, receipt.Total);
        }
    }
}
