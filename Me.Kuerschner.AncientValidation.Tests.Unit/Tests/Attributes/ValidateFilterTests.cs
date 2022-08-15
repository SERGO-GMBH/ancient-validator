using System.Linq;
using Me.Kuerschner.AncientValidation.Exceptions;
using Me.Kuerschner.AncientValidation.Tests.Unit.Helper;
using Me.Kuerschner.AncientValidation.Tests.Unit.Models;
using Me.Kuerschner.AncientValidation.Tests.Unit.Validator;
using Xunit;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Tests.Attributes
{
    public class ValidateFilterTests
    {
        [Fact]
        public void Should_Validate_IHaveValidator_Success()
        {
            var filter = new ValidateFilter();
            var attribute = new ValidateAttribute() { ValidatorType = typeof(CustomerIHave) };
            
            var model = CustomerHelper.GetCustomerIHave();

            try
            {
                filter.Validate(new[] { model }, new[] { attribute });
            } catch(ValidationException exception)
            {
                Assert.Fail(exception.ValidationResult.ToString());
            }
        }

        [Fact]
        public void Should_Validate_Failure()
        {
            var filter = new ValidateFilter();
            var attribute = new ValidateAttribute() { ValidatorType = typeof(CustomerIHave) };

            var model = CustomerHelper.GetFailureIHave();

            try
            {
                filter.Validate(new[] { model }, new[] { attribute });
            }
            catch (ValidationException exception)
            {
                Assert.False(exception.ValidationResult.IsValid);
            }
        }

        [Fact]
        public void Should_Validate_Validator_Success()
        {
            var filter = new ValidateFilter();
            var attribute = new ValidateAttribute() { ValidatorType = typeof(UserSusiValidator) };

            var model = UserHelper.GetSusi();

            try
            {
                filter.Validate(new[] { model }, new[] { attribute });
            }
            catch (ValidationException ex)
            {
                Assert.False(ex.ValidationResult.IsValid);
            }
        }

        [Fact]
        public void Should_Validate_Validator_Failure()
        {
            var filter = new ValidateFilter();
            var attribute = new ValidateAttribute() { ValidatorType = typeof(UserSusiValidator) };

            var model = UserHelper.GetErrorUser();

            try
            {
                filter.Validate(new[] { model }, new[] { attribute });
            }
            catch (ValidationException exception)
            {
                Assert.False(exception.ValidationResult.IsValid);
            }
        }

        [Fact]
        public void Should_GetPairs_Success()
        {
            var filter = new ValidateFilter();
            var attribute = new ValidateAttribute() { ValidatorType = typeof(CustomerIHave) };

            var model = CustomerHelper.GetCustomerIHave();

            var pairs = filter.GetValidatorPair(new[] { model }, new[] { attribute });

            Assert.Equal(1, pairs.Count);
            Assert.Equal(typeof(CustomerIHave), pairs.First().Key.GetType());
            Assert.Equal(typeof(CustomerIHave), pairs.First().Value);
        }
    }
}
