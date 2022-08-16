using Me.Kuerschner.AncientValidation.Constants;
using Me.Kuerschner.AncientValidation.Exceptions;
using Me.Kuerschner.AncientValidation.Extensions;
using Me.Kuerschner.AncientValidation.Helper;
using Me.Kuerschner.AncientValidation.Models;
using Me.Kuerschner.AncientValidation.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Me.Kuerschner.AncientValidation
{
    internal class LanguageSingleton
    {
        #region Properties

        private static readonly LanguageSingleton _instance = new LanguageSingleton();
        private const string LANGUAGE_NOT_FOUND_MESSAGE = "Not language was registered.";

        public List<Language> Languages { get; private set; } = new List<Language>();
        #endregion

        #region Constructor
        private LanguageSingleton()
        {
            OnInit();
        }

        #endregion

        #region Public Methods

        public string GetDefaultLanguageCode()
        {
            var selectedLanguage = GetLanguage(PropertyConstants.DEFAULT_LANGUAGE);

            if (selectedLanguage != null)
            {
                return selectedLanguage.LanguageCode;
            }

            selectedLanguage = Languages.FirstOrDefault();

            if (selectedLanguage != null)
            {
                return selectedLanguage.LanguageCode;
            }

            throw new LanguageNotFoundException(message: LANGUAGE_NOT_FOUND_MESSAGE);
        }

        public Language GetLanguage(string languageCode)
        {
            return Languages.Where(item => item.LanguageCode.EqualsIgnoreCase(languageCode)).FirstOrDefault();
        }

        public Language GetDefaultLanguage() => GetLanguage(GetDefaultLanguageCode());

        public Language GetFirstLanguage()
        {
            return Languages.FirstOrDefault();
        }

        public KeyValuePair<string, string> GetTranslation(Language language, ErrorKey errorKeys)
        {
            var translation = language.Translations.Where(item => item.Key.EqualsIgnoreCase(errorKeys.ToString())).FirstOrDefault();
            
            if (translation.Key == null)
                translation = new KeyValuePair<string, string>(errorKeys.ToString(), "{0}");

            return translation;
        }

        public Error GetError(string languageCode, ErrorKey errorKeys)
        {
            var language = GetLanguage(languageCode);
            var keyValuePair = GetTranslation(language, errorKeys);

            var error = new Error()
            {
                ErrorKey = errorKeys,
                ErrorMessage = keyValuePair.Value
            };
            return error;
        }

        #endregion

        #region Private Methods

        private void OnInit()
        {
            if (!IsAnyConfigExists())
            {
                var language = BuildDefaultLanguage();
                var json = JsonConvert.SerializeObject(language);
                Directory.CreateDirectory(PropertyConstants.CONFIG_FOLDER);
                File.WriteAllText(PropertyConstants.CONFIG_FOLDER + "/" + PropertyConstants.DEFAULT_LANGUAGE + "_messages.json", json);
            }

            Assembly assembly = AssemblyHelper.GetCurrent();
            var resources = assembly.GetManifestResourceNames().GetMessageResources();
        
            foreach(var resource in resources)
            {
                Languages.Add(LoadLanguage(resource));
            }
        }

        public Language LoadLanguage(string resourceName)
        {
            var assembly = AssemblyHelper.GetCurrent();
            var stream = assembly.GetManifestResourceStream(resourceName);

            using (var streamReader = new StreamReader(stream, encoding: Encoding.UTF8))
            {
                var content = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Language>(content);
            }
        }

        private bool IsAnyConfigExists()
        {
            return Directory.Exists(PropertyConstants.CONFIG_FOLDER);
        }

        private Language BuildDefaultLanguage()
        {
            var language = new Language()
            {
                LanguageCode = PropertyConstants.DEFAULT_LANGUAGE,
                LanguageName = PropertyConstants.DEFAULT_LANGUAGE_DISPLAY,
                Translations = new Dictionary<string, string>()
            };
            foreach (var value in Enum.GetValues(typeof(ErrorKey)))
            {
                language.Translations.Add(value.ToString(), "{0}");
            }
            return language;
        }

        #endregion

        #region Static Methods
        public static LanguageSingleton GetInstance() => _instance;
        #endregion
    }
}
