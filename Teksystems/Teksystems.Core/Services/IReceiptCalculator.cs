using System;
using System.Collections.Generic;
using System.Text;
using Teksystems.Core.Models;

namespace Teksystems.Core.Services
{
    public interface IReceiptCalculator
    {
        Receipt Calculate(ShoppingCart cart);
    }
}
