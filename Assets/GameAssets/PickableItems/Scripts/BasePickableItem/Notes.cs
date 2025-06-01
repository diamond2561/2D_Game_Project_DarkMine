[System.Serializable]
public class Note
{
    public string titleKey; // Ключ для заголовка заметки (например, "note_title_01")
    public string contentKey; // Ключ для содержания заметки (например, "note_content_01")

    // Методы для получения локализованного текста
    public string GetLocalizedTitle()
    {
        return LanguageData.LOCALIZATION[titleKey][LanguageData.CURRENT_LANGUAGE];
    }

    public string GetLocalizedContent()
    {
        return LanguageData.LOCALIZATION[contentKey][LanguageData.CURRENT_LANGUAGE];
    }
}