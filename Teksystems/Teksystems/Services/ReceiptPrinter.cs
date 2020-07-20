using System.IO;
using System.Text;
using System.Threading.Tasks;
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

        public async Task PrintAsync(Receipt receipt)
        {
            using (var writer = new StreamWriter(this.output, Encoding.Default, 1024, true))
            {
                foreach (var entry in receipt.Entries)
                {
                    await writer.WriteAsync(entry.Count.ToString());

                    if (entry.Item.IsImported)
                    {
                        await writer.WriteAsync(" imported");
                    }

                    await writer.WriteLineAsync($" {entry.Item.Name}: {entry.Total}");
                }

                await writer.WriteLineAsync($"Sales Taxes: {receipt.Taxes} Total: {receipt.Total}");
                await writer.WriteLineAsync();
                await writer.FlushAsync();
            }
        }
    }
}
