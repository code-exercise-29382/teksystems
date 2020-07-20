using System.Threading.Tasks;
using Teksystems.Core.Models;

namespace Teksystems.Core.Services
{
    public interface ITaxCalculator
    {
        Task<decimal> CalculateTaxAsync(Item item, int count);
    }
}
