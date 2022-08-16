using System.Collections.Generic;
using System.Linq;

namespace Me.Kuerschner.AncientValidation.Extensions
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string value, string compare)
        {
            if (value == null && compare == null) return true;
            if (value == null || compare == null) return false;
            return value.ToLower().Equals(compare.ToLower());
        }

        public static IEnumerable<string> GetMessageResources(this string[] array)
        {
            return array.Where(item => item.EndsWith("messages.json")).ToList();
        }
    }
}
