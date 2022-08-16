using Me.Kuerschner.AncientValidation.Contracts;
using Me.Kuerschner.AncientValidation.Tests.Unit.Helper;
using Xunit;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Tests.Rules
{
    public class RuleBuilderObjectExtensionsTest
    {
        private readonly IAncientValidator _ancientValidator;

        public RuleBuilderObjectExtensionsTest()
        {
            _ancientValidator = new AncientValidator();
        }

        [Fact]
        public void Test_Must_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.DisplayName).Must(item => item.Equals("Susi Schnaubert")).Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_Must_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.DisplayName).Must(item => item.Equals("Susi Schnaubert")).Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_IsEquals_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.DisplayName).IsEquals(user.DisplayName).Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_IsEquals_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.DisplayName).IsEquals("Hallihallo").Result();

            Assert.False(value.IsValid);
        }
    }
}
