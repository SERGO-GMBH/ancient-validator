using System.Reflection;

namespace Me.Kuerschner.AncientValidation.Reflections
{
    internal class BaseValiationHandlerReflection : BaseReflection
    {
        public BaseValiationHandlerReflection(object validator, object model) : base(validator)
        {
            SetValidationObject(model);
        }

        public void SetValidationObject(object model)
        {
            var methods = BaseObject.GetType().GetMethod("SetValidationObject", BindingFlags.NonPublic | BindingFlags.Instance);
            methods.Invoke(BaseObject, new[] { model });
        }

        public ValidationResult Result()
        {
            var createResultMethod = BaseObject.GetType().GetMethod("Result", BindingFlags.NonPublic | BindingFlags.Instance);
            return (ValidationResult)createResultMethod.Invoke(BaseObject, new object[0]);
        }
    }
}
