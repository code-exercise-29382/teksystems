using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Teksystems.Core.Models;
using Teksystems.Services;
using Teksystems.Tests.Mocks;
using Teksystems.Tests.Mocks.Services;
using Xunit;

namespace Teksystems.Tests
{
    public class ReceiptPrinterTests
    {
        private readonly ReceiptCalculator receiptCalculator;
        private readonly TestReceiptPrinter receiptPrinter;

        public ReceiptPrinterTests()
        {
            this.receiptCalculator = new ReceiptCalculator(new InMemoryItemsRepository(), new TaxCalculator(0.1m, 0.05m));
            this.receiptPrinter = TestReceiptPrinter.Create();
        }

        public static IEnumerable<object[]> ShoppingCartSampleData
        {
            get
            {
                var cart1 = new ShoppingCart();
                cart1.Add(ItemIds.Input1_Book, 1);
                cart1.Add(ItemIds.Input1_MusicCD, 1);
                cart1.Add(ItemIds.Input1_ChocolateBar, 1);
                yield return new object[] { cart1, @"1 book: 12.49
1 music CD: 16.49
1 chocolate bar: 0.85
Sales Taxes: 1.50 Total: 29.83" };

                var cart2 = new ShoppingCart();
                cart2.Add(ItemIds.Input2_ImportedBoxOfChocolate, 1);
                cart2.Add(ItemIds.Input2_ImportedBottleOfPerfume, 1);
                yield return new object[] { cart2, @"1 imported box of chocolates: 10.50
1 imported bottle of perfume: 54.65
Sales Taxes: 7.65 Total: 65.15" };

                var cart3 = new ShoppingCart();
                cart3.Add(ItemIds.Input3_ImportedBottleOfPerfume, 1);
                cart3.Add(ItemIds.Input3_BottleOfPerfume, 1);
                cart3.Add(ItemIds.Input3_HeadachePills, 1);
                cart3.Add(ItemIds.Input3_ImportedChocolates, 1);
                yield return new object[] { cart3, @"1 imported bottle of perfume: 32.19
1 bottle of perfume: 20.89
1 packet of headache pills: 9.75
1 imported box of chocolates: 11.85
Sales Taxes: 6.70 Total: 74.68" };

                var cart4 = new ShoppingCart();
                cart4.Add(ItemIds.Input1_Book, 2);
                cart4.Add(ItemIds.Input2_ImportedBoxOfChocolate, 1);
                cart4.Add(ItemIds.Input3_BottleOfPerfume, 5);
                cart4.Add(ItemIds.FreeItem, 1);
                yield return new object[] { cart4, @"2 book: 24.98
1 imported box of chocolates: 10.50
5 bottle of perfume: 104.45
1 free stuff: 0.00
Sales Taxes: 10.00 Total: 139.93" };
            }
        }

        [Theory]
        [MemberData(nameof(ShoppingCartSampleData))]
        public async Task ReceiptCalcultor_WithSampleShoppingCartData_CalculatesTaxesAndTotalCorrectly(ShoppingCart cart, string expectedOutput)
        {
            var receipt = await this.receiptCalculator.CalculateAsync(cart);
            await this.receiptPrinter.PrintAsync(receipt);

            // Trimming end to remove extra line breaks
            var result = this.receiptPrinter.GetOutputAsString().TrimEnd();

            Assert.Equal(expectedOutput, result, true);
        }

        private class TestReceiptPrinter : ReceiptPrinter
        {
            private readonly MemoryStream stream;

            private TestReceiptPrinter(MemoryStream stream) 
                : base(stream)
            {
                this.stream = stream;
            }

            public string GetOutputAsString()
            {
                return Encoding.Default.GetString(stream.ToArray());
            }

            public static TestReceiptPrinter Create()
            {
                return new TestReceiptPrinter(new MemoryStream());
            }
        }
    }
}
