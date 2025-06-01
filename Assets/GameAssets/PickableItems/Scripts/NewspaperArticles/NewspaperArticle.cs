using UnityEngine;

public class NewspaperArticle : BasePickableItem
{
    public Note note; // Данные заметки

    protected override void OnCollect()
    {
        // Получаем локализованные данные заметки
        string localizedTitle = note.GetLocalizedTitle();
        string localizedContent = note.GetLocalizedContent();
    }

    public void DisableNoteOnMap()
    {
        gameObject.SetActive(false);
    }
}
