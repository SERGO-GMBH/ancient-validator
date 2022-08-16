using Me.Kuerschner.AncientValidation.Contracts;
using Me.Kuerschner.AncientValidation.Tests.Unit.Helper;
using Xunit;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Tests.Rules
{
    public class RuleBuilderStringExtensionsTest
    {
        private readonly IAncientValidator _ancientValidator;

        public RuleBuilderStringExtensionsTest()
        {
            _ancientValidator = new AncientValidator();
        }

        [Fact]
        public void Test_NotNull_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.DisplayName).NotNull().Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_IsEquals_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Password).IsEquals(item => item.PasswordConfirm).Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_IsEquals_Failure()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Password).IsEquals(item => item.PasswordConfirm).Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_NotNull_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.FirstName).NotNull().Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_NotEmpty_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.DisplayName).NotEmpty().Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_IsEmail_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Email).IsEmail().Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_IsPhoneNumber_Success()
        {
            var user = UserHelper.GetSusi();

            var value = _ancientValidator.RuleFor(user, item => item.Phone).IsPhoneNumber().Result();

            Assert.True(value.IsValid);
        }

        [Fact]
        public void Test_IsPhoneNumber_Failure()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.Phone).IsPhoneNumber().Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_NotEmpty_Error()
        {
            var user = UserHelper.GetErrorUser();

            var value = _ancientValidator.RuleFor(user, item => item.DisplayName).NotEmpty().Result();

            Assert.False(value.IsValid);
        }

        [Fact]
        public void Test_NotEmpty_TestNullable()
        {
            var user = UserHelper.GetErrorUser();
            user.DisplayName = null;

            var value = _ancientValidator.RuleFor(user, item => item.DisplayName).NotEmpty().Result();

            Assert.False(value.IsValid);
        }
    }
}
