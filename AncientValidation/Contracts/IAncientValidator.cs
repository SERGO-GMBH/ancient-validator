using System;
using System.Linq.Expressions;

namespace Me.Kuerschner.AncientValidation.Contracts
{
    public interface IAncientValidator
    {
        void Visualize<TModel>(IHaveValidator<TModel> haveValidator) where TModel : class, IHaveValidator<TModel>, new();
        ValidationResult ValidateModel<TValidatorObject>(TValidatorObject model) where TValidatorObject : class, IHaveValidator<TValidatorObject>, new();
        ValidationResult Validate(object model, Type validator);
        ValidationResult Validate<TObject>(TObject tObject, IBaseValidator<TObject> baseValidator) where TObject : class, new();
        ValidationResult Validate<TValidator, TObject>(TObject tObject) where TValidator : IValidator<TObject>, new() where TObject : class, new();
        ValidationResult Validate<TValidator, TObject>(TObject tObject, string languageCode) where TValidator : IValidator<TObject>, new() where TObject : class, new();
        RuleBuilder<TObject, TReturn> RuleFor<TObject, TReturn>(TObject tObject, Expression<Func<TObject, TReturn>> property) where TObject : class, new();
    }
}
