using System.Threading.Tasks;
using Teksystems.Core.Models;
using Teksystems.Core.Services;
using Teksystems.Utils;

namespace Teksystems.Services
{
    public class TaxCalculator : ITaxCalculator
    {
        private const decimal TaxRoundsUpTo = 0.05m;

        private readonly decimal salesTax;
        private readonly decimal importTax;

        public TaxCalculator(decimal salesTax, decimal importTax)
        {
            this.salesTax = salesTax;
            this.importTax = importTax;
        }

        public Task<decimal> CalculateTaxAsync(Item item, int count)
        {
            var subtotal = item.Price * count;
            decimal tax = 0;
            if (!item.IsExemptFromBasicSalesTax)
            {
                tax += RoundHelper.RoundToNearest(subtotal * this.salesTax, TaxRoundsUpTo);
            }

            if (item.IsImported)
            {
                tax += RoundHelper.RoundToNearest(subtotal * this.importTax, TaxRoundsUpTo);
            }

            return Task.FromResult(subtotal + tax);
        }
    }
}
