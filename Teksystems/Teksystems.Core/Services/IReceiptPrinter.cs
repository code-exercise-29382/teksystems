using System.Threading.Tasks;
using Teksystems.Core.Models;

namespace Teksystems.Core.Services
{
    public interface IReceiptPrinter
    {
        Task PrintAsync(Receipt receipt);
    }
}
