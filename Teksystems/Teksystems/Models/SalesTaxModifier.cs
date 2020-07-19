using System;

namespace Teksystems.Models
{
    [Flags]
    public enum SalesTaxModifier
    {
        None = 0x00,

        ExemptFromBasicTax = 0x01,

        Imported = 0x02,
    }
}