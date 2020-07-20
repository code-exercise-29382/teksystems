using Teksystems.Core.Models;

namespace Teksystems.Core.Services
{
    public interface ITaxCalculator
    {
        decimal CalculateTax(Item item, int count);
    }
}
