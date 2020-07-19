using System;

namespace Teksystems.Utils
{
    /// <summary>
    /// This is a helper class specific for this exercise. Usually the item ID would be supplied from the system, 
    /// but to make it easier to code, I've hard-coded those ids for quick reference.
    /// </summary>
    public static class ItemIds
    {
        public static readonly Guid Input1_Book = Guid.NewGuid();
        public static readonly Guid Input1_MusicCD = Guid.NewGuid();
        public static readonly Guid Input1_ChocolateBar = Guid.NewGuid();

        public static readonly Guid Input2_ImportedBoxOfChocolate = Guid.NewGuid();
        public static readonly Guid Input2_ImportedBottleOfPerfume = Guid.NewGuid();
        
        public static readonly Guid Input3_ImportedBottleOfPerfume = Guid.NewGuid();
        public static readonly Guid Input3_BottleOfPerfume = Guid.NewGuid();
        public static readonly Guid Input3_HeadachePills = Guid.NewGuid();
        public static readonly Guid Input3_ImportedChocolates = Guid.NewGuid();
    }
}
