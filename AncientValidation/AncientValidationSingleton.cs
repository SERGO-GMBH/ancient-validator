
using Me.Kuerschner.AncientValidation.Models.Options;

namespace Me.Kuerschner.AncientValidation
{
    internal class AncientValidationSingleton
    {
        private static AncientValidationSingleton _instance = new AncientValidationSingleton();

        public AncientValidationOptions Options { get; set; }

        private AncientValidationSingleton() { }

        #region Static Methods
        public static AncientValidationSingleton GetInstance() => _instance;
        #endregion


    }
}
