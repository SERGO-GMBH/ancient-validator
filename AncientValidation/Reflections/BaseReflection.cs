
namespace Me.Kuerschner.AncientValidation.Reflections
{
    internal abstract class BaseReflection
    {
        public object BaseObject { get; set; }

        public BaseReflection(object obj)
        {
            BaseObject = obj;
        }
    }
}
