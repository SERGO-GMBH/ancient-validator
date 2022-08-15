using System;
using Me.Kuerschner.AncientValidation.Contracts;
using Me.Kuerschner.AncientValidation.Tests.Unit.Helper;
using Xunit;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Tests.Rules
{
    public class RuleBuilderDateTimeExtensionsTest
    {
        private readonly IAncientValidator _ancientValidator;

        public RuleBuilderDateTimeExtensionsTest()
        {
            _ancientValidator = new AncientValidator();
        }

        [Fact]
        public void Test_IsEquals_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Birthday).IsEquals(user.Birthday).Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_IsEquals_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Birthday).IsEquals(DateTime.Now).Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_EarlierThan_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Birthday).EarlierThan(DateTime.Now).Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_EarlierThan_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Birthday).EarlierThan(DateTime.Now).Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_LaterThan_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Birthday).LaterThan(DateTime.Now.AddYears(-50)).Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_LaterThan_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Birthday).LaterThan(DateTime.Now.AddYears(10)).Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_Between_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Birthday).Between(DateTime.Now.AddYears(-30), DateTime.Now.AddYears(50)).Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_Between_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Birthday).Between(DateTime.Now.AddYears(10), DateTime.Now.AddYears(50)).Result();

            Assert.False(value.IsValid);
        }
    }
}
