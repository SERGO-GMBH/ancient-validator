using System;
using System.IO;

namespace Me.Kuerschner.AncientValidation.Exceptions
{
    public class LanguageNotFoundException : IOException
    {
        public LanguageNotFoundException()
        {

        }

        public LanguageNotFoundException(string message) : base(message)
        {

        }

        public LanguageNotFoundException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
