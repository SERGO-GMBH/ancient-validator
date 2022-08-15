using Me.Kuerschner.AncientValidation;
using Me.Kuerschner.AncientValidation.Contracts;

namespace Me.Kuerschner.AncientValidator.WebApi.Models
{
    public class LoginCredentialsDto : IHaveValidator<LoginCredentialsDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Alter { get; set; }
        
        public void Validate(BaseValidationHandler<LoginCredentialsDto> validator)
        {
            validator.RuleFor(item => item.Alter)
                .Between(12, 99);

            validator.RuleFor(item => item.Password)
                .NotNull()
                .NotEmpty();

            validator.RuleFor(item => item.UserName)
                .NotNull()
                .NotEmpty();               
        }
    }
}
