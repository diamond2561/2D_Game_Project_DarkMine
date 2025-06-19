using System.Collections.Generic;
using UnityEngine;

public class PlayerNotepad : MonoBehaviour
{
    private static PlayerNotepad _instance;
    public static PlayerNotepad Instance => _instance;

    private List<NoteData> savedNotes = new List<NoteData>();
    private NoteSaver noteSaver;
    private NotepadUIHandler uiHandler;

    [SerializeField] private GamePause _gamePause;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        noteSaver = new NoteSaver();
        uiHandler = GetComponent<NotepadUIHandler>();
        uiHandler.Initialize(_gamePause);

        LoadNotes();
    }

    private void Start()
    {
        uiHandler.UpdateNotesUI(savedNotes, OpenNoteByIndex);
        uiHandler.ToggleNotepad(); // Скрываем блокнот при старте
    }

    public void AddItem(NewspaperArticle article)
    {
        savedNotes.Add(new NoteData(article.note.titleKey, article.note.contentKey));
        SaveNotes();
        uiHandler.UpdateNotesUI(savedNotes, OpenNoteByIndex);
    }

    public void ToggleNotepad() => uiHandler.ToggleNotepad();

    private void OpenNoteByIndex(int index)
    {
        if (index >= 0 && index < savedNotes.Count)
            uiHandler.DisplayNote(savedNotes[index]);
    }

    private void SaveNotes() => noteSaver.Save(savedNotes);

    private void LoadNotes() => savedNotes = noteSaver.Load();

    public void ClearNotes()
    {
        savedNotes.Clear();
        SaveNotes();
        uiHandler.UpdateNotesUI(savedNotes, OpenNoteByIndex);
        Debug.Log("Заметки очищены");
    }
}