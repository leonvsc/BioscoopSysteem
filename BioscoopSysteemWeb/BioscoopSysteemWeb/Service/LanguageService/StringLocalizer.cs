using System.Collections.Generic;
using System;
using Microsoft.Extensions.Localization;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace BioscoopSysteemWeb.Service.LanguageService
{
    public class BiosStringLocalizer<TComponent> : IStringLocalizer<TComponent>
    {
        public LocalizedString this[string name] => FindLocalziedString(name);
        public LocalizedString this[string name, params object[] arguments] => FindLocalziedString(name, arguments);

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }
        private readonly Microsoft.Extensions.Options.IOptions<LocalizationOptions> _localizationOptions;

        public BiosStringLocalizer(Microsoft.Extensions.Options.IOptions<LocalizationOptions> localizationOptions)
        {
            _localizationOptions = localizationOptions;
        }

        private LocalizedString FindLocalziedString(string key, object[]? arguments = default)
        {
            var resourceManager = CreateResourceManager();
            LocalizedString result;

            try
            {
                string value = resourceManager.GetString(key);

                if (arguments is not null)
                {
                    value = string.Format(value, arguments);
                }

                result = new(key, value, false, GetResourceLocaltion());
            }
            catch
            {
                result = new(key, "", true, GetResourceLocaltion());
            }

            return result;
        }

        private ResourceManager CreateResourceManager()
        {
            string resourceLocaltion = GetResourceLocaltion();
            var resourceManager = new ResourceManager(resourceLocaltion, Assembly.GetExecutingAssembly());

            return resourceManager;
        }

        private string GetResourceLocaltion()
        {
            var componentType = typeof(TComponent);
            var nameParts = componentType.FullName.Split('.').ToList();
            nameParts.Insert(1, _localizationOptions.Value.ResourcesPath);
            string resourceLocaltion = string.Join(".", nameParts);

            return resourceLocaltion;
        }

    }
}
