using System.Collections.Generic;

namespace Me.Kuerschner.AncientValidation.Models
{
    public class Language
    {
        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }
        public IDictionary<string, string> Translations { get; set; }
    }
}
