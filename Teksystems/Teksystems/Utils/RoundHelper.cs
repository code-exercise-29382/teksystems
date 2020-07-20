using System;
using System.Collections.Generic;
using System.Text;

namespace Teksystems.Utils
{
    public static class RoundHelper
    {
        /// <summary>
        /// Rounds up to target value
        /// </summary>
        public static decimal RoundToNearest(decimal value, decimal roundTarget)
        {
            if(roundTarget == 0)
            {
                throw new DivideByZeroException("Cannot round to 0.");
            }

            return Math.Ceiling(value / roundTarget) * roundTarget;
        }
    }
}
