using Me.Kuerschner.AncientValidation.Contracts;
using Me.Kuerschner.AncientValidation.Reflections;
using System;
using System.Linq;
using System.Reflection;

namespace Me.Kuerschner.AncientValidation.Helper
{
    internal class ValidatorHelper
    {
        public static IValidator<TObject> Find<TObject>(Assembly assembly) where TObject : class, new()
        {
            return assembly.GetTypes().FirstOrDefault(item => item.GetType() == (typeof(TObject))) as IValidator<TObject>;
        }

        public static object GetBaseValidationHandler(Type model)
        {
            var baseValidatorGeneric = typeof(BaseValidationHandler<>);
            var baseValidatorGenericType = baseValidatorGeneric.MakeGenericType(model);
            return Activator.CreateInstance(baseValidatorGenericType, nonPublic: true);
        }

        public static BaseValiationHandlerReflection GetBaseValidationHandlerReflection(object model)
        {
            var baseValidatorGeneric = typeof(BaseValidationHandler<>);
            var baseValidatorGenericType = baseValidatorGeneric.MakeGenericType(model.GetType());
            var validation = Activator.CreateInstance(baseValidatorGenericType, nonPublic: true);
            return new BaseValiationHandlerReflection(validation, model);
        }

        public static IBaseValidationReflection GetValidatorReflection(Type validatorType)
        {
            var validate = Activator.CreateInstance(validatorType);
            return new IBaseValidationReflection(validate);
        }

        public static IBaseValidationReflection GetValidatorReflection(object instance)
        {
            return new IBaseValidationReflection(instance);
        }
    }
}
