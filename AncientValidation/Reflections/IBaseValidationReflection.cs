using System;
using System.Reflection;

namespace Me.Kuerschner.AncientValidation.Reflections
{
    internal class IBaseValidationReflection : BaseReflection
    {
        public IBaseValidationReflection(object obj) : base(obj)
        {
        }

        public void Validate(object iBaseValidator)
        {
            var method = BaseObject.GetType().GetMethod("Validate", new[] { iBaseValidator.GetType() });
            method.Invoke(BaseObject, new[] { iBaseValidator });
        }
    }
}
