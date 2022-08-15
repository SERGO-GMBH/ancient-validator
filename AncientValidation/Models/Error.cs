using Me.Kuerschner.AncientValidation.Models.Enums;

namespace Me.Kuerschner.AncientValidation.Models
{
    public class Error
    {
        public ErrorKey ErrorKey { get; set; }
        public string ErrorMessage { get; set; }
        public string ClassName { get; set; }
        public string PropertyName { get; set; }

        public Error Clone()
        {
            return new Error()
            {
                ErrorKey = ErrorKey,
                ErrorMessage = ErrorMessage
            };
        }
    }
}
