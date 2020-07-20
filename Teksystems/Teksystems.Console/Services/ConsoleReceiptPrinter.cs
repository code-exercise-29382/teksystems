using System.IO;
using Teksystems.Services;

namespace Teksystems.Console.Services
{
    public class ConsoleReceiptPrinter : ReceiptPrinter
    {
        public ConsoleReceiptPrinter() : base(System.Console.OpenStandardOutput())
        {
        }
    }
}
