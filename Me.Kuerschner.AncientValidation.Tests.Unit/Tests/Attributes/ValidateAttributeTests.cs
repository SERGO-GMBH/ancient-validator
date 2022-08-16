using System;
using Me.Kuerschner.AncientValidation.Tests.Unit.Tests.Helper;
using Me.Kuerschner.AncientValidation.Tests.Unit.Validator;
using Xunit;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Tests.Attributes
{
    public class ValidateAttributeTests
    {
        [Fact]
        public void Should_Validate_TypeInput_Success()
        {
            var filter = new ValidateAttribute()
            {
                ValidatorType = typeof(AddressValidator)
            };

            Assert.NotNull(filter.ValidatorType);
        }

        [Fact]
        public void Should_Validate_TypeInput_Failure()
        {
            try
            {
                var filter = new ValidateAttribute()
                {
                    ValidatorType = typeof(DateHelperTest)
                };
                Assert.NotNull(filter.ValidatorType);
            } catch(ArgumentException exception)
            {
                Assert.Equal("ValidationType", exception.Message);
            }
        }
    }
}
