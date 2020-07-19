using System;
using System.Collections.Generic;
using System.Text;
using Teksystems.Models;

namespace Teksystems.Services
{
    public interface IReceiptCalculator
    {
        Receipt Calculate(ShoppingCart cart);
    }
}
