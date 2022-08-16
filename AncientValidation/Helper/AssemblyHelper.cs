using System.Reflection;

namespace Me.Kuerschner.AncientValidation.Helper
{
    internal class AssemblyHelper
    {
        public static Assembly GetCurrent()
        {
            return Assembly.GetAssembly(typeof(AssemblyHelper)  );
        }
    }
}
