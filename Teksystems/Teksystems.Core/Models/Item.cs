using System.Diagnostics.Tracing;

namespace Teksystems.Core.Models
{
    public class Item
    {
        private readonly SalesTaxModifier modifier;

        public Item(string name, decimal price, SalesTaxModifier modifier = SalesTaxModifier.None)
        {
            Name = name;
            Price = price;
            this.modifier = modifier;
        }

        public string Name { get; }

        public decimal Price { get; }

        public bool IsExemptFromBasicSalesTax => this.modifier.HasFlag(SalesTaxModifier.ExemptFromBasicTax);

        public bool IsImported => this.modifier.HasFlag(SalesTaxModifier.Imported);
    }
}