using System;
using System.Collections.Generic;
using System.Text;
using Teksystems.Core.Models;

namespace Teksystems.Core.Services
{
    public interface IReceiptPrinter
    {
        void Print(Receipt receipt);
    }
}
