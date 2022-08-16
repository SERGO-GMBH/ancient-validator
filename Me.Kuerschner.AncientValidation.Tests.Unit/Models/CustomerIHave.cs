using System;
using Me.Kuerschner.AncientValidation.Contracts;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Models
{
    [Serializable]
    public class CustomerIHave : IHaveValidator<CustomerIHave>
    {
        public string? DisplayName { get; set; }
        
        public void Validate(BaseValidationHandler<CustomerIHave> validator)
        {
            validator.RuleFor(item => item.DisplayName).NotNull().NotEmpty();
        }
    }
}
