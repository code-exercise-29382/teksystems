namespace Teksystems.Core.Models
{
    public class ReceiptEntry
    {
        public ReceiptEntry(Item item, int count, decimal total)
        {
            Item = item;
            Count = count;
            Total = total;
        }

        public Item Item { get; }

        public int Count { get; }

        public decimal Total { get; }
    }
}
