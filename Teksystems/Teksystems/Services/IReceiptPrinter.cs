using System;
using System.Collections.Generic;
using System.Text;
using Teksystems.Models;

namespace Teksystems.Services
{
    public interface IReceiptPrinter
    {
        string Print(Receipt receipt);
    }
}
