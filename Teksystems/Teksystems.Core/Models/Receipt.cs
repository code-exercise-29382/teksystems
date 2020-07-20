using System;
using System.Collections.Generic;
using System.Text;

namespace Teksystems.Core.Models
{
    public class Receipt
    {
        public Receipt(IReadOnlyList<ReceiptEntry> entries, decimal subtotal, decimal total)
        {
            Entries = entries;
            Subtotal = subtotal;
            Total = total;
        }

        public IReadOnlyList<ReceiptEntry> Entries { get; }

        public decimal Subtotal { get; }

        public decimal Total { get; }

        public decimal Taxes => this.Total - this.Subtotal;
    }
}
