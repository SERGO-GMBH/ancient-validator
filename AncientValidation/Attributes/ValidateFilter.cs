using Me.Kuerschner.AncientValidation.Exceptions;
using Me.Kuerschner.AncientValidation.Helper;
using Me.Kuerschner.AncientValidation.Reflections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Me.Kuerschner.AncientValidation
{
    public class ValidateFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.ActionDescriptor is ControllerActionDescriptor action)
            {
                var validateAttribute = GetValidateAttribute(action);

                try
                {
                    var arguments = context.ActionArguments;
                    Validate(arguments.Values, validateAttribute);
                }
                catch (ValidationException exception)
                {
                    context.Result = new BadRequestObjectResult(exception.ValidationResult);
                }
            }
        }

        public void Validate(IEnumerable<object> objects, IEnumerable<ValidateAttribute> validateAttributes)
        {
            var mapDir = GetValidatorPair(objects, validateAttributes);

            foreach(var item in mapDir)
            {
                var baseValidationHandler = ValidatorHelper.GetBaseValidationHandlerReflection(item.Key);
                var iBaseValidationHandler = GetBaseValidation(item);
                iBaseValidationHandler.Validate(baseValidationHandler.BaseObject);
                var result = baseValidationHandler.Result();

                if (!result.IsValid)
                {
                    throw new ValidationException(result);
                }
            }
        }

        private IBaseValidationReflection GetBaseValidation(KeyValuePair<object, Type> item)
        {
            if (item.Key.GetType() == item.Value)
                return ValidatorHelper.GetValidatorReflection(item.Key);
            else
                return ValidatorHelper.GetValidatorReflection(item.Value);
        }

        public IDictionary<object, Type> GetValidatorPair(IEnumerable<object> objects, IEnumerable<ValidateAttribute> validateAttributes)
        {
            Dictionary<object, Type> validatorMapping = new Dictionary<object, Type>();

            foreach(object item in objects)
            {
                Type validatorType = GetValidationType(item, validateAttributes);
                if(validatorType != null)
                {
                    validatorMapping.Add(item, validatorType);
                    continue;
                }
                if(IsValidatorForType(item.GetType(), item.GetType()))
                {
                    validatorMapping.Add(item, item.GetType());
                    continue;
                }
            }
            return validatorMapping;
        }

        private Type GetValidationType(object model, IEnumerable<ValidateAttribute> validateAttributes)
        {
            var validationType = validateAttributes.Where(item => IsValidatorForType(item.ValidatorType, model.GetType())).FirstOrDefault();
            if(validationType == null)
            {
                return null;
            }
            return validationType.ValidatorType;
        }

        private bool IsValidatorForType(Type validatorType, Type modelType)
        {
            if (validatorType == null) return false;
            var validators = validatorType.GetInterfaces();
            foreach(var validatorBase in validators)
            {
                var generic = validatorBase.GetGenericArguments()[0];
                if(generic == modelType)
                {
                    return true;
                }
            }
            return false;
        }


        private object GetValidator<TObject>(TObject obj, Type type, Type validatorType) where TObject : new() 
        {
            var validate = Activator.CreateInstance(validatorType);
            return validate;
        }

        private IEnumerable<ValidateAttribute> GetValidateAttribute(ControllerActionDescriptor controllerActionDescriptor)
        {
            var validationAttributes = new List<ValidateAttribute>();
            var actionAttributes = controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(ValidateAttribute), inherit: true);
            
            if(actionAttributes != null && actionAttributes.Length > 0)
            {
                validationAttributes.AddRange(actionAttributes.Select(item => item as ValidateAttribute));
            }

            var controllerAttributes = controllerActionDescriptor.ControllerTypeInfo.GetCustomAttributes(typeof(ValidateAttribute), inherit: true);
            if (controllerAttributes != null && controllerAttributes.Length > 0)
            {
                validationAttributes.AddRange(controllerAttributes.Select(item => item as ValidateAttribute));
            }

            return validationAttributes;
        }
    }
}
