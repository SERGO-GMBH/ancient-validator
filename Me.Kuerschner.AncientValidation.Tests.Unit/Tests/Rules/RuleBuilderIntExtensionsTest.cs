using Me.Kuerschner.AncientValidation.Contracts;
using Me.Kuerschner.AncientValidation.Tests.Unit.Helper;
using Xunit;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Tests.Rules
{
    public class RuleBuilderIntExtensionsTest
    {

        private readonly IAncientValidator _ancientValidator;

        public RuleBuilderIntExtensionsTest()
        {
            _ancientValidator = new AncientValidator();
        }

        [Fact]
        public void Test_Divisible_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Id).Divisible(5).Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_Divisible_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Id).Divisible(5).Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_Between_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Id).Between(4, 10).Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_Between_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Id).Between(4, 10).Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_HigherThan_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Id).HigherThan(4).Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_HigherThan_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Id).HigherThan(4).Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_LowerThan_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Id).LowerThan(10).Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_LowerThan_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Id).LowerThan(2).Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_NotNull_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Level).NotNull().Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_NotNull_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Level).NotNull().Result();

            Assert.True(value.IsValid);
        }
    }
}
