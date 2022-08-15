using Me.Kuerschner.AncientValidation.Contracts;
using Me.Kuerschner.AncientValidation.Tests.Unit.Helper;
using Me.Kuerschner.AncientValidation.Tests.Unit.Validator;
using Xunit;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Tests.Rules
{

    public class RuleBuilderEnumerableTests
    {
        private readonly IAncientValidator _ancientValidator;

        public RuleBuilderEnumerableTests()
        {
            _ancientValidator = new AncientValidator();
        }
        
        [Fact]
        public void Test_Collection_Success()
        {
            var user = UserHelper.GetSusi();

            var result = _ancientValidator.RuleFor(user, item => item.Roles).ForEach(role => {
                role.SetValidator(new UserSusiValidator());
            }).Result();

            Assert.True(result.IsValid);
        }
    }
}
