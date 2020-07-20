using Teksystems.Utils;
using Xunit;

namespace Teksystems.Tests
{
    public class RoundHelperTests
    {
        [Theory]
        [InlineData(10.00, 0.05, 10.00)]
        [InlineData(10.01, 0.05, 10.05)]
        [InlineData(12.34, 0.5, 12.50)]
        public void Round_WhenUsingFractionalRounding_RoundsUpToNearestValue(decimal value, decimal roundTo, decimal expected)
        {
            var result = RoundHelper.RoundToNearest(value, roundTo);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10.00, 2, 10.00)]
        [InlineData(11.11, 2, 12.00)]
        [InlineData(123.12, 10, 130.00)]
        public void Round_WhenUsingIntegerRounding_RoundsUpToNearestValue(decimal value, decimal roundTo, decimal expected)
        {
            var result = RoundHelper.RoundToNearest(value, roundTo);

            Assert.Equal(expected, result);
        }
    }
}
