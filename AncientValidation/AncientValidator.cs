using Me.Kuerschner.AncientValidation.Contracts;
using Me.Kuerschner.AncientValidation.Helper;
using System;
using System.Linq.Expressions;

namespace Me.Kuerschner.AncientValidation
{
    public class AncientValidator : IAncientValidator
    {
        public ValidationResult Validate(object model, Type validator)
        {
            return ValidatorHelper.GetBaseValidationHandlerReflection(model).Result();
        }

        public ValidationResult Validate<TObject>(TObject tObject, IBaseValidator<TObject> baseValidator) where TObject : class, new()
        {
            var validator = new BaseValidationHandler<TObject>(tObject);
            baseValidator.Validate(validator);
            return validator.Result();
        }

        public ValidationResult Validate<TValidator, TObject>(TObject tObject) where TValidator : IValidator<TObject>, new() where TObject : class, new() 
        {
            var validator = new BaseValidationHandler<TObject>(tObject);
            var validatorInstance = new TValidator();
            validatorInstance.Validate(validator);
            return validator.Result();
        }

        public ValidationResult Validate<TValidator, TObject>(TObject tObject, string languageCode) where TValidator : IValidator<TObject>, new() where TObject : class, new()
        {
            var validator = new BaseValidationHandler<TObject>(tObject);
            validator.LanguageCode = languageCode;
            var validatorInstance = new TValidator();
            validatorInstance.Validate(validator);
            return validator.Result();
        }

        public RuleBuilder<TObject, TReturn> RuleFor<TObject, TReturn>(TObject tObject, Expression<Func<TObject, TReturn>> property) where TObject : class, new()
        {
            return new BaseValidationHandler<TObject>(tObject).RuleFor(property);
        }

        public ValidationResult ValidateModel<TValidatorObject>(TValidatorObject model) where TValidatorObject : class, IHaveValidator<TValidatorObject>, new()
        {
            return ExecuteValidation(model, model);
        }

        private ValidationResult ExecuteValidation<TValidator, TObject>(TValidator validator, TObject tObject) where TValidator : IBaseValidator<TObject>, new() where TObject : class, new()
        {
            var validatorHandler = new BaseValidationHandler<TObject>(tObject);
            validator.Validate(validatorHandler);
            return validatorHandler.Result();
        }

        public void Visualize<TModel>(IHaveValidator<TModel> haveValidator) where TModel : class, IHaveValidator<TModel>, new()
        {


        }
    }
}
