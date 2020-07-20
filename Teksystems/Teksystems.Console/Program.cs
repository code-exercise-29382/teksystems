using System.Collections.Generic;
using Teksystems.Console.Services;
using Teksystems.Core.Models;
using Teksystems.Services;

namespace Teksystems.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            var printer = new ConsoleReceiptPrinter();
            var calculator = new ReceiptCalculator(new InMemoryItemsRepository(), new TaxCalculator(0.10m, 0.05m));

            foreach (var cart in CreateSampleShoppingCarts())
            {
                var receipt = calculator.Calculate(cart);
                printer.Print(receipt);
            }
        }

        public static IEnumerable<ShoppingCart> CreateSampleShoppingCarts()
        {
            var cart1 = new ShoppingCart();
            cart1.Add(ItemIds.Input1_Book, 1);
            cart1.Add(ItemIds.Input1_ChocolateBar, 1);
            cart1.Add(ItemIds.Input1_MusicCD, 1);
            yield return cart1;

            var cart2 = new ShoppingCart();
            cart2.Add(ItemIds.Input2_ImportedBottleOfPerfume, 1);
            cart2.Add(ItemIds.Input2_ImportedBoxOfChocolate, 1);
            yield return cart2;

            var cart3 = new ShoppingCart();
            cart3.Add(ItemIds.Input3_BottleOfPerfume, 1);
            cart3.Add(ItemIds.Input3_HeadachePills, 1);
            cart3.Add(ItemIds.Input3_ImportedBottleOfPerfume, 1);
            cart3.Add(ItemIds.Input3_ImportedChocolates, 1);
            yield return cart3;
        }

    }
}
