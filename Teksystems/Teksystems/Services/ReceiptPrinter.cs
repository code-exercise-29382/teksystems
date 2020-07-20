using System.IO;
using System.Text;
using Teksystems.Core.Models;
using Teksystems.Core.Services;

namespace Teksystems.Services
{
    public abstract class ReceiptPrinter : IReceiptPrinter
    {
        private readonly Stream output;

        protected ReceiptPrinter(Stream output)
        {
            this.output = output;
        }

        public void Print(Receipt receipt)
        {
            using (var writer = new StreamWriter(this.output, Encoding.Default, 1024, true))
            {
                foreach (var entry in receipt.Entries)
                {
                    writer.Write(entry.Count);

                    if (entry.Item.IsImported)
                    {
                        writer.Write(" imported");
                    }

                    writer.WriteLine(" {0}: {1}", entry.Item.Name, entry.Total);
                }

                writer.WriteLine("Sales Taxes: {0} Total: {1}", receipt.Taxes, receipt.Total);
                writer.WriteLine();
                writer.Flush();
            }
        }
    }
}
