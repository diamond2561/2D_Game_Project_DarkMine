using UnityEngine;

public class NewspaperArticle : BasePickableItem
{
    public Note note; // Данные заметки

    protected override void OnCollect()
    {
        // Добавляем заметку в менеджер заметок

        // NoteManager.Instance.AddNote(note);
        Debug.Log($"Заметка добавлена: {note.title}\nТекст заметки: {note.content}");
    }

    public void DisableNoteOnMap()
    {
        gameObject.SetActive(false);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Paper/Paper", GetComponent<Transform>().position);// Юрий добавил для звука записок
    }
}
