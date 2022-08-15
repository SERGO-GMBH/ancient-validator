using Me.Kuerschner.AncientValidation.Contracts;
using Me.Kuerschner.AncientValidation.Models.Enums;
using System;

namespace Me.Kuerschner.AncientValidation
{
    public static class RuleBuilderObjectExtensions
    {
        public static RuleBuilder<TObject, TReturn> NotNull<TObject, TReturn>(this RuleBuilder<TObject, TReturn> ruleBuilder) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value != null;
            }, ErrorKey.NotNull);
        }

        public static RuleBuilder<TObject, TReturn> IsEquals<TObject, TReturn>(this RuleBuilder<TObject, TReturn> ruleBuilder, TReturn value) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return ruleBuilder.Value.Equals(value);
            }, ErrorKey.Equals, args: value?.ToString());
        }

        public static RuleBuilder<TObject, TReturn> Must<TObject, TReturn>(this RuleBuilder<TObject, TReturn> ruleBuilder, Func<TReturn, bool> expression) where TObject : class, new()
        {
            return RuleExecutor.Check(ruleBuilder, item =>
            {
                return expression(ruleBuilder.Value);
            }, ErrorKey.Must);
        }

        public static RuleBuilder<TObject, TReturn> SetValidator<TObject, TReturn>(this RuleBuilder<TObject, TReturn> ruleBuilder, IValidator<TReturn> validator, bool errorNull = false) where TObject : class, new() where TReturn : class, new()
        {
            if (ruleBuilder == null) return ruleBuilder;
            if (ruleBuilder.Value == null)
                if (errorNull)
                {
                    ruleBuilder.AddError(ErrorKey.NotNull);
                    return ruleBuilder;
                }
                else
                    return ruleBuilder;
            if (validator != null)
            {
                var baseValidator = new BaseValidationHandler<TReturn>(ruleBuilder.Value);
                validator.Validate(baseValidator);
                var result = baseValidator.Result();

                foreach(var item in result.Errors)
                {
                    ruleBuilder.AddError(item);
                }
            }
            return ruleBuilder;
        }
    }
}
