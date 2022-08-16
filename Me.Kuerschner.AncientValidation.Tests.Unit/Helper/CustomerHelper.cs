using Me.Kuerschner.AncientValidation.Tests.Unit.Models;

namespace Me.Kuerschner.AncientValidation.Tests.Unit.Helper
{
    public static class CustomerHelper
    {
        public static CustomerIHave GetCustomerIHave()
        {
            return new CustomerIHave()
            {
                DisplayName = "Dennis Kürschner"
            };
        }

        public static CustomerIHave GetFailureIHave()
        {
            return new CustomerIHave()
            {
                DisplayName = ""
            };
        }

    }
}
