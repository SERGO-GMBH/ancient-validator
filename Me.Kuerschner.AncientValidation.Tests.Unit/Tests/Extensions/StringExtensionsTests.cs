using Me.Kuerschner.AncientValidation.Extensions;
using Xunit;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void Should_AreEqual_Success()
        {
            const string string1 = "Hallo";
            const string string2 = "hallo";

            var success = string1.EqualsIgnoreCase(string2);

            Assert.True(success);
        }

        [Fact]
        public void Should_AreEqualNull_Success()
        {
            const string? string1 = null;
            const string? string2 = null;

            var success = string1.EqualsIgnoreCase(string2);

            Assert.True(success);
        }
    }
}
