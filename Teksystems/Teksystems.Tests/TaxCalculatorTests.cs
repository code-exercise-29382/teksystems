using Teksystems.Core.Models;
using Teksystems.Services;
using Xunit;

namespace Teksystems.Tests
{
    public class TaxCalculatorTests
    {
        [Theory]
        [InlineData(0.1, 10.0, 11.0)]
        [InlineData(0.12, 12.34, 13.84)]
        [InlineData(0, 10.0, 10.0)]
        public void CalculateTax_WhenOnlySalesTax_IncludesSalesTax(decimal salesTax, decimal itemPrice, decimal expectedTaxes)
        {
            var item = new Item("Test", itemPrice);
            var calculator = new TaxCalculator(salesTax, 1);

            var result = calculator.CalculateTax(item, 1);

            Assert.Equal(expectedTaxes, result);
        }

        [Theory]
        [InlineData(0.1, 10.0, 11.0)]
        [InlineData(0.12, 12.34, 13.84)]
        [InlineData(0, 10.0, 10.0)]
        public void CalculateTax_WhenOnlyImportTax_IncludesImportTax(decimal importTax, decimal itemPrice, decimal expectedTaxes)
        {
            var item = new Item("Test", itemPrice, SalesTaxModifier.ExemptFromBasicTax | SalesTaxModifier.Imported);
            var calculator = new TaxCalculator(1, importTax);

            var result = calculator.CalculateTax(item, 1);

            Assert.Equal(expectedTaxes, result);
        }

        [Theory]
        [InlineData(0.1, 0.05, 10.0, 11.5)]
        [InlineData(0.12, 0.15, 12.34, 15.74)]
        [InlineData(0.05, 0.1, 10.0, 11.5)]
        public void CalculateTax_WhenBothTax_IncludesBothTax(decimal salesTax, decimal importTax, decimal itemPrice, decimal expectedTaxes)
        {
            var item = new Item("Test", itemPrice, SalesTaxModifier.Imported);
            var calculator = new TaxCalculator(salesTax, importTax);

            var result = calculator.CalculateTax(item, 1);

            Assert.Equal(expectedTaxes, result);
        }

        [Theory]
        [InlineData(0.1, 0.05, 10.0)]
        [InlineData(0.12, 0.15, 12.34)]
        [InlineData(0.05, 0.1, 10.0)]
        public void CalculateTax_WhenItemNotTaxed_ReturnsZero(decimal salesTax, decimal importTax, decimal itemPrice)
        {
            var item = new Item("Test", itemPrice, SalesTaxModifier.ExemptFromBasicTax);
            var calculator = new TaxCalculator(salesTax, importTax);

            var result = calculator.CalculateTax(item, 1);

            Assert.Equal(itemPrice, result);
        }

        [Theory]
        [InlineData(0.1, 0.05, 3, 10.0, 34.5)]
        [InlineData(0.12, 0.15, 10, 12.34, 156.8)]
        [InlineData(0.05, 0.1, 4, 10.0, 46.0)]
        public void CalculateTax_WhenMoreThanOneItem_CalculatesTaxOnTotal(decimal salesTax, decimal importTax, int itemCount, decimal itemPrice, decimal expectedTax)
        {
            var item = new Item("Test", itemPrice, SalesTaxModifier.Imported);
            var calculator = new TaxCalculator(salesTax, importTax);

            var result = calculator.CalculateTax(item, itemCount);

            Assert.Equal(expectedTax, result);
        }
    }
}
