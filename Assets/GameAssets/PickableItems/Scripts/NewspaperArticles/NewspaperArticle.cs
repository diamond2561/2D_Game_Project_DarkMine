using UnityEngine;

public class NewspaperArticle : BasePickableItem
{
    public Note note; // Данные заметки

    protected override void OnCollect()
    {
        // Получаем локализованные данные заметки
        string localizedTitle = note.GetLocalizedTitle();
        string localizedContent = note.GetLocalizedContent();

        // Добавляем заметку в менеджер заметок
        // NoteManager.Instance.AddNote(note);

        // Выводим информацию в консоль
        Debug.Log($"Заметка добавлена: {localizedTitle}\nТекст заметки: {localizedContent}");
    }

    public void DisableNoteOnMap()
    {
        gameObject.SetActive(false);
    }
}
