using System;

namespace Me.Kuerschner.AncientValidation.Helper
{
    public static class DateHelper
    {
        public static DateTime GetMinDateTime(DateTime value1, DateTime value2)
        {
            return value1 > value2 ? value2 : value1;
        }

        public static DateTime GetMaxDateTime(DateTime value1, DateTime value2)
        {
            return value2 > value1 ? value2 : value1;
        }
    }
}
