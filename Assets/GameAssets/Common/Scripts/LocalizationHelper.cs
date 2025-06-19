public static class LocalizationHelper
{
    public static string Get(string key)
    {
        return LanguageData.LOCALIZATION[key][LanguageData.CURRENT_LANGUAGE];
    }
}