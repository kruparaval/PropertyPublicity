using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace OMTechStation.PropertyPublicity.Localization
{
    public static class PropertyPublicityLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(PropertyPublicityConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(PropertyPublicityLocalizationConfigurer).GetAssembly(),
                        "OMTechStation.PropertyPublicity.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
