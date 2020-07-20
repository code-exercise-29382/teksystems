using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teksystems.Core.Models;

namespace Teksystems.Core.Services
{
    public interface IReceiptCalculator
    {
        Task<Receipt> CalculateAsync(ShoppingCart cart);
    }
}
