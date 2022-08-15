using Me.Kuerschner.AncientValidation.Contracts;
using Me.Kuerschner.AncientValidation.Models;
using Me.Kuerschner.AncientValidation.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Me.Kuerschner.AncientValidation
{
    public class BaseValidationHandler<TObject> where TObject : class, new()
    {
        #region Properties
        public TObject ValidationObject { get; private set; }
        public string LanguageCode { get; set; }
        internal List<Error> Errors { get; set; } = new List<Error>();
        #endregion

        #region Constructor
        internal BaseValidationHandler()
        {
            LanguageCode = LanguageSingleton.GetInstance().GetDefaultLanguageCode();
        }

        internal BaseValidationHandler(TObject tObject)
        {
            ValidationObject = tObject;
            LanguageCode = LanguageSingleton.GetInstance().GetDefaultLanguageCode();
        }

        #endregion

        #region Public Methods
        

        
        
        public RuleBuilder<TObject, TType> RuleFor<TType>(Expression<Func<TObject, TType>> func)
        {
            
            
            
            
            return new RuleBuilder<TObject, TType>(this, func, ValidationObject);
        }

        public void SetValidator(IValidator<TObject> validator, bool errorNull = false)
        {
            if (this.ValidationObject == null)
            {
                if (errorNull)
                {
                    AddError(ErrorKey.NotNull);
                }
            }

            if (validator != null)
            {
                var baseValidator = new BaseValidationHandler<TObject>(ValidationObject);
                validator.Validate(baseValidator);
                var result = baseValidator.Result();

                foreach (var item in result.Errors)
                {
                    AddError(item);
                }
            }
        }

        #endregion

        #region Internal Methods
        internal void SetValidationObject(object obj)
        {
            ValidationObject = obj as TObject;
        }

        internal void AddError(ErrorKey errorKeys, params string[] values)
        {
            var languageSingleton = LanguageSingleton.GetInstance();
            var validationObjectName = ValidationObject.GetType().Name;
            var error = languageSingleton.GetError(LanguageCode, errorKeys);
            AddError(error, "", validationObjectName, values);
        }

        internal void AddError(Error error, string propertyName, string clazzName, params string[] values)
        {
            Error newError = error.Clone();
            newError.PropertyName = propertyName;
            newError.ClassName = clazzName; 
            newError.ErrorMessage = string.Format(newError.ErrorMessage, GetParams(propertyName, values));
            Errors.Add(newError);
        }

        internal void AddError(Error errorDirect)
        {
            Errors.Add(errorDirect);
        }

        internal ValidationResult Result()
        {
            return new ValidationResult(errors: Errors);
        }

        #endregion

        #region Private Methods
        private string[] GetParams(string property, params string[] values)
        {
            var list = new List<string>();
            list.Add(property);
            if(values != null) {
                list.AddRange(values);
            }
            return list.ToArray();
        }
        #endregion
    }
}
