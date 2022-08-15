using System;
using Me.Kuerschner.AncientValidation.Contracts;
using Me.Kuerschner.AncientValidation.Tests.Unit.Models;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Validator
{
    public class UserSusiValidator : IValidator<User>, IValidator<Address>, IValidator<Roles>
    {
        public void Validate(BaseValidationHandler<User> validator)
        {
            validator.RuleFor(item => item.Address)
                .NotNull();


            validator.RuleFor(item => item.Birthday)
                .EarlierThan(DateTime.Today.Subtract(TimeSpan.FromDays(6570)));
        }

        public void Validate(BaseValidationHandler<Address> validator)
        {
            validator.RuleFor(item => item.Street)
                .NotNull();
        }

        public void Validate(BaseValidationHandler<Roles> validator)
        {

        }
        
    }
}
