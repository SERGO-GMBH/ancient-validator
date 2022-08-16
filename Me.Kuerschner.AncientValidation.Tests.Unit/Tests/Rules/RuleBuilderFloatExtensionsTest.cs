using Me.Kuerschner.AncientValidation.Contracts;
using Me.Kuerschner.AncientValidation.Tests.Unit.Helper;
using Xunit;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Tests.Rules
{
    public class RuleBuilderFloatExtensionsTest
    {
        private readonly IAncientValidator _ancientValidator;

        public RuleBuilderFloatExtensionsTest()
        {
            _ancientValidator = new AncientValidator();
        }
        
        [Fact]
        public void Test_Divisible_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Boni).Divisible(5).Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_Divisible_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Boni).Divisible(5).Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_Between_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Boni).Between(4, 15).Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_Between_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Boni).Between(4, 10).Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_HigherThan_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Boni).HigherThan(4).Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_HigherThan_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Boni).HigherThan(4).Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_LowerThan_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Boni).LowerThan(11).Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_LowerThan_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Boni).LowerThan(0).Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_NotNull_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Level).NotNull().Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_Even_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Boni).Even().Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_Event_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Boni).Even().Result();

            Assert.True(value.IsValid);
        }
    }
}
