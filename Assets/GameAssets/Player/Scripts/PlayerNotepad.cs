using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerNotepad : MonoBehaviour
{
    private List<NoteData> savedNotes = new List<NoteData>();

    private static PlayerNotepad _instance;
    public static PlayerNotepad Instance => _instance;

    [SerializeField] private GamePause _gamePause;

    [SerializeField] private GameObject notepadPanel; // Панель блокнота (ScrollView)
    [SerializeField] private Button buttonPrefab;      // Префаб кнопки заметки
    [SerializeField] private Transform contentPanel;   // Объект Content внутри Scroll View

    [SerializeField] private TextMeshProUGUI _noteTitle;
    [SerializeField] private TextMeshProUGUI _noteContent;

    private bool isFirstRun;

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
        }
    }

    private void Start()
    {
        Debug.Log("Путь к файлу: " + GetSavePath());

        // Загружаем сохранённые заметки, если они есть
        LoadNotes();

        notepadPanel.SetActive(false);
        CreateNotesButton();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNotepad();
        }
    }

    public void AddItem(NewspaperArticle newspaperArticle)
    {
        NoteData data = new NoteData(
            newspaperArticle.note.titleKey,
            newspaperArticle.note.contentKey
        );

        savedNotes.Add(data);
        Debug.Log("Заметка добавлена в блокнот");

        CreateNotesButton();
        SaveNotes(); // Сохраняем сразу после добавления
    }

    public void ToggleNotepad()
    {
        notepadPanel.SetActive(!notepadPanel.activeSelf);

        if (notepadPanel.activeSelf)
        {
            _gamePause.PauseGame();   // Ставим игру на паузу
        }
        else
        {
            _gamePause.UnpauseGame(); // Снимаем с паузы
        }
    }

    private void CreateNotesButton()
    {
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        int noteIndex = 0;

        foreach (NoteData data in savedNotes)
        {
            Button newButton = Instantiate(buttonPrefab, contentPanel);

            noteIndex++;
            TMP_Text buttonText = newButton.GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
            {
                buttonText.text = "Note " + noteIndex;
            }

            // Создаём временную копию NewspaperArticle для открытия
            newButton.onClick.AddListener(() =>
            {
                var tempNote = new Note { titleKey = data.titleKey, contentKey = data.contentKey };
                var tempArticle = new GameObject().AddComponent<NewspaperArticle>();
                tempArticle.note = tempNote;

                OpenNote(tempArticle);
            });
        }
    }

    private void OpenNote(NewspaperArticle article)
    {
        Debug.Log("Открыта заметка: " + article.note.GetLocalizedTitle());
        // Здесь реализуй логику отображения самой заметки
        _noteTitle.text = article.note.GetLocalizedTitle();
        _noteContent.text = article.note.GetLocalizedContent();
    }

    private string GetSavePath()
    {
        return Path.Combine(Application.persistentDataPath, "notepad_save.json");
    }

    public void SaveNotes()
    {
        string dataJson = JsonUtility.ToJson(new NoteDataListWrapper { notes = savedNotes });
        File.WriteAllText(GetSavePath(), dataJson);
        Debug.Log("Заметки сохранены!");
    }

    public void LoadNotes()
    {
        string path = GetSavePath();

        if (File.Exists(path))
        {
            string dataJson = File.ReadAllText(path);
            NoteDataListWrapper wrapper = JsonUtility.FromJson<NoteDataListWrapper>(dataJson);

            savedNotes = wrapper.notes;
            Debug.Log($"Загружено заметок: {savedNotes.Count}");
        }
        else
        {
            Debug.Log("Файл сохранения не найден.");
        }
    }

    public void ClearNotes()
    {
        savedNotes.Clear();
        CreateNotesButton(); // Обновляем UI
        SaveNotes(); // Сохраняем пустой список
        Debug.Log("Заметки очищены");
    }   
}