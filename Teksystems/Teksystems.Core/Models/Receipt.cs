using System;
using System.Collections.Generic;
using System.Text;

namespace Teksystems.Core.Models
{
    public class Receipt
    {
        public Receipt(IReadOnlyList<ReceiptEntry> entries, decimal total)
        {
            Entries = entries;
            Total = total;
        }

        public IReadOnlyList<ReceiptEntry> Entries { get; }
        
        public decimal Total { get; }
    }
}
