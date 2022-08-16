using Me.Kuerschner.AncientValidation.Contracts;
using System;
using System.Linq;

namespace Me.Kuerschner.AncientValidation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ValidateAttribute : Attribute
    {
        private Type validationType;

        public Type ValidatorType
        {
            get { return validationType; }
            set { 
                if(!CanApplyType(value)) throw new ArgumentException("ValidationType");
                    validationType = value; 
            }
        }

        public bool CanApplyType(Type type)
        {
            return type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseValidator<>));
        }
    }
}
