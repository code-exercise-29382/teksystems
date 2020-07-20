namespace Teksystems.Core.Models
{
    public class ReceiptEntry
    {
        public ReceiptEntry(Item item, int count, decimal subtotal, decimal total)
        {
            Item = item;
            Count = count;
            Subtotal = subtotal;
            Total = total;
        }

        public Item Item { get; }

        public int Count { get; }

        public decimal Subtotal { get; }

        public decimal Total { get; }
    }
}
