using System;
using Me.Kuerschner.AncientValidation.Contracts;
using Me.Kuerschner.AncientValidation.Tests.Unit.Models;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Validator
{
    public class AddressValidator : IValidator<Address>
    {
        public void Validate(BaseValidationHandler<Address> validator)
        {
            throw new NotImplementedException();
        }
    }
}
