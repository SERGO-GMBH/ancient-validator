using Me.Kuerschner.AncientValidation.Models;
using Me.Kuerschner.AncientValidation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Me.Kuerschner.AncientValidation
{
    public class RuleBuilder<TObject, TReturn> where TObject : class, new()
    {
        internal BaseValidationHandler<TObject> BaseValidator { get; set; }
        internal TObject ValidationObject { get; set; }
        internal bool CascadeExit { get; set; }


        #region Private Properties
        private Expression<Func<TObject, TReturn>> _expression;
        #endregion

        internal TReturn Value
        {
            get
            {
                return _expression.Compile().Invoke(ValidationObject);
            }
        }

        internal RuleBuilder(BaseValidationHandler<TObject> baseValidator, Expression<Func<TObject, TReturn>> property, TObject value)
        {
            BaseValidator = baseValidator;
            ValidationObject = value;
            _expression = property;
        }

        internal void AddError(ErrorKey errorKeys, params string[] values)
        {
            if (errorKeys == ErrorKey.NotNull) CascadeExit = true;
            var memberExpression = (MemberExpression)_expression.Body;
            var languageSingleton = LanguageSingleton.GetInstance();
            var validationObjectName = ValidationObject.GetType().Name;
            var error = languageSingleton.GetError(BaseValidator.LanguageCode, errorKeys);
            BaseValidator.AddError(error, memberExpression.Member.Name, validationObjectName, values);
        }

        internal void AddError(Error error)
        {
            BaseValidator.AddError(error);
        }

        internal void AddErrors(IEnumerable<Error> errors)
        {
            foreach (var item in errors)
            {
                BaseValidator.AddError(item);
            }
        }

        internal void ExecuteExpression<TValue>(Action<TValue> expression)
        {
             
        }

        public ValidationResult Result()
        {
            return new ValidationResult(errors: BaseValidator.Errors);
        }
    }
}
